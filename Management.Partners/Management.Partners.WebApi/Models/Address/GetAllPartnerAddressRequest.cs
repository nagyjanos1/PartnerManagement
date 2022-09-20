namespace Management.Partners.WebApi.Models.Address
{
    public record GetAllPartnerAddressRequest : GetAllRequest
    {
        public Guid PartnerId { get; init; }
    }
}
