using Management.Partners.Infrastructure.Base;

namespace Management.Partners.Infrastructure.Entities
{
    internal class Address : BaseEntity
    {
        public string Name { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string AddressValue { get; set; }

        public virtual Partner Partner { get; set; }

        public Guid PartnerId { get; set; }
    }
}