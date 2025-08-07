using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Contracts.Commands;

namespace Management.Partners.WebApi.Requests.Contract;

public record DeleteContractRequest
{
    [Required]
    public Guid Id { get; init; }

    internal DeleteContractCommand GetCommand()
    {
        return new DeleteContractCommand
        {
            Id = Id
        };
    }
}