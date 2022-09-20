using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Commands;

namespace Management.Partners.WebApi.Models.Address
{
    public record AddAddressRequest
    {
        [Required]
        [MaxLength(400)]
        public string Name { get; init; }

        [Required]
        [MaxLength(3)]
        public string CountryCode { get; init; }

        [Required]
        [MaxLength(8)]
        public string ZipCode { get; init; }

        [Required]
        [MaxLength(400)]
        public string City { get; init; }

        [Required]
        [MaxLength(1000)]
        public string AddressValue { get; init; }

        [Required]
        public Guid PartnerId { get; init; }

        internal AddAddressCommand GetCommand()
        {
            return new()
            {
                Name = Name,
                CountryCode = CountryCode,
                ZipCode = ZipCode,
                City = City,
                AddressValue = AddressValue,
                PartnerId = PartnerId.ToString()
            };
        }
    }
}
