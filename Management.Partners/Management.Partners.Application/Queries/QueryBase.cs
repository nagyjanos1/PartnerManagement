namespace Management.Partners.Application.Queries;

public record QueryBase
{
    public virtual int Skip { get; init; } = 0;

    public virtual int Take { get; init; } = 15;

    public virtual string OrderBy { get; init; }

    public virtual bool IsDescending { get; init; } = true;
}
