using Management.Partners.Infrastructure.Base;

namespace Management.Partners.Infrastructure.Models
{
    internal class Address : BaseModel
    {
        public string Name { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string AddressValue { get; set; }
    }
}