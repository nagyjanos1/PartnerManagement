using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Partners.Commands;

namespace Management.Partners.WebApi.Requests.Partner;

public record DeletePartnerRequest
{
    [Required]
    public Guid Id { get; init; }

    internal DeletePartnerCommand GetCommand()
    {
        return new ()
        {
            Id = Id
        };
    }
}
