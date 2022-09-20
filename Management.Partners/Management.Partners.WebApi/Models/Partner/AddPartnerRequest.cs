using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Commands;

namespace Management.Partners.WebApi.Models.Partner
{
    public record AddPartnerRequest
    {
        [Required]
        [MaxLength(400)]
        public string Name { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [Phone]
        public string Phone { get; init; }

        public string Description { get; init; }

        internal AddPartnerCommand GetCommand()
        {
            return new ()
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Description = Description
            };
        }
    }
}
