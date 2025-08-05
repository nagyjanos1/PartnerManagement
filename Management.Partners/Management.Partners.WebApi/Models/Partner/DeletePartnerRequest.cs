using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Commands;

namespace Management.Partners.WebApi.Models.Partner;

public record DeletePartnerRequest
{
    [Required]
    public Guid Id { get; init; }

    internal DeletePartnerCommand GetCommand()
    {
        return new ()
        {
            Id = Id.ToString()
        };
    }
}
