using Management.Partners.WebApi.Requests;

namespace Management.Partners.WebApi.Requests.Address;

public record GetAllPartnerAddressRequest : GetAllRequest
{
    public Guid PartnerId { get; init; }
}
