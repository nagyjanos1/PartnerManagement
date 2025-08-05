using Management.Partners.Domain.Base;
using Management.Partners.Domain.Documents;

namespace Management.Partners.Domain.Contracts;

public record Contract : BaseModel, IAggregateRoot
{
    public static Contract NoContract => new()
    {
        Id = Guid.Empty,
        Subject = string.Empty,
        Description = null,
        CreatedAt = DateTime.MinValue,
        LastUpdatedAt = null,
        Status = ContractStatus.None,
        StartDate = DateOnly.MinValue,
        EndDate = DateOnly.MinValue,
        GrossValue = 0,
        NetValue = 0,
        VatValue = 0,
        Currency = string.Empty,
        Documents = null,
        Histories = null
    };

    public required string Subject { get; init; }

    public string Description { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public DateTime? LastUpdatedAt { get; init; }

    public bool CanModify { get { return Status is ContractStatus.New or ContractStatus.Audited; } }

    public ContractStatus Status { get; init; }

    public required DateOnly StartDate { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public DateOnly EndDate { get; init; }

    public decimal GrossValue { get; init; }

    public decimal NetValue { get; init; }

    public decimal VatValue { get; init; }

    public string Currency { get; init; }

    public IReadOnlyCollection<Document> Documents { get; init; } = [];

    public IReadOnlyCollection<ContractHistory> Histories { get; init; } = [];

    private Contract()
    {
        Status = ContractStatus.New;
    }

    public static Contract Create(string subject, DateOnly startDate)
    {
        return new Contract { Subject = subject, StartDate = startDate };
    }

    public static Contract Create(string subject, DateOnly startDate, DateOnly endDate)
    {
        return new Contract { Subject = subject, StartDate = startDate, EndDate = endDate };
    }

    public Contract SetAuthorizedState()
    {
        return SetStatus(ContractStatus.Audited);
    }

    public Contract SetRunningState()
    {
        return SetStatus(ContractStatus.Running);
    }

    public Contract SetClosedState()
    {
        return SetStatus(ContractStatus.Closed);
    }

    public Contract AddNetValue(decimal netValue, decimal vatValue, string currency)
    {
        return this with
        {
            NetValue = netValue,
            GrossValue = netValue + netValue * vatValue * (decimal)0.01,
            VatValue = vatValue,
            Currency = currency
        };
    }

    public Contract AddGrossValue(decimal grossValue, decimal vatValue, string currency)
    {
        return this with
        {
            GrossValue = grossValue,
            // TODO: fix it
            NetValue = grossValue - grossValue * vatValue * (decimal)0.01,
            VatValue = vatValue,
            Currency = currency
        };
    }

    public Contract AddDescription(string newDescription)
    {
        var historized = AddHistory(nameof(Description), Description, newDescription);
        return historized with { Description = newDescription };
    }

    public Contract AddDocuments(params Document[] documents)
    {
        var (oldFilesNames, newFilesNames) = ExtractDocumentsNames(documents);
        var historied = AddHistory(nameof(Documents), oldFilesNames, newFilesNames);
        return historied with { Documents = [.. documents] };
    }

    public Contract RemoveDocuments(params Document[] documents)
    {
        var remainedDocuments = Documents.Where(d => documents.Contains(d) is false).ToArray();
        var (oldDocumentsNames, newDocumentsNames) = ExtractDocumentsNames(remainedDocuments);
        var historied = AddHistory(nameof(Documents), oldDocumentsNames, newDocumentsNames);
        return this with { Documents = [.. remainedDocuments] };
    }

    private (string oldDocumentsNames, string newDocumentsName) ExtractDocumentsNames(params Document[] documents)
    {
        var oldDocumentsNames = Documents.Count > 0 ? string.Join(';', Documents.Select(x => x.Name)) : null;
        var newDocumentsNames = documents.Length > 0 ? string.Join(';', documents.Select(x => x.Name)) : null;
        return (oldDocumentsNames, newDocumentsNames);
    }

    private Contract AddHistory(string fieldName, string fieldOldValue, string fieldNewValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fieldName);

        return this with
        {
            Histories =
            [
                .. Histories,
                ContractHistory.Create(nameof(Status), fieldNewValue, fieldOldValue)
            ],
            LastUpdatedAt = DateTime.UtcNow
        };
    }

    private Contract SetStatus(ContractStatus contractStatus)
    {
        var historized = AddHistory(nameof(Status), Status.ToString(), contractStatus.ToString());
        return historized with
        {
            Status = contractStatus
        };
    }
}
