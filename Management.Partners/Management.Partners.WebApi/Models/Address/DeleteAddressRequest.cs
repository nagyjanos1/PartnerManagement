using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Commands;

namespace Management.Partners.WebApi.Models.Address;

public record DeleteAddressRequest
{
    [Required]
    public Guid Id { get; init; }

    internal DeleteAddressCommand GetCommand()
    {
        return new()
        {
            Id = Id.ToString(),
        };
    }
}
