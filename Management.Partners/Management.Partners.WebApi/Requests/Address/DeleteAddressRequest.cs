using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Partners.Commands;

namespace Management.Partners.WebApi.Requests.Address;

public record DeleteAddressRequest
{
    [Required]
    public Guid Id { get; init; }

    internal DeleteAddressCommand GetCommand()
    {
        return new()
        {
            Id = Id,
        };
    }
}
