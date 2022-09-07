using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Entities
{
    public record Address : BaseEntity, IValueObject
    {
        public string Name { get; init; }

        public string CountryCode { get; init; }

        public string ZipCode { get; init; }

        public string City { get; init; }

        public string Address { get; init; }

    }
}
