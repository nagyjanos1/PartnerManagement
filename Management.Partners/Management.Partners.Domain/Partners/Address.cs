using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Partners
{
    public record Address : BaseModel, IValueObject
    {
        public string Name { get; init; }

        public string CountryCode { get; init; }

        public string ZipCode { get; init; }

        public string City { get; init; }

        public string AddressValue { get; init; }

        public string PartnerId { get; set; }
    }
}
