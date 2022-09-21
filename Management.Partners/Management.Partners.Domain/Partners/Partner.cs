using Management.Partners.Domain.Base;
using Management.Partners.Domain.Interfaces;

namespace Management.Partners.Domain.Partners
{
    public sealed record Partner : BaseModel, IAggregateRoot
    {
        public string Name { get; init; }

        public string Email { get; init; }

        public string Phone { get; init; }

        public string Description { get; init; }

        public List<Address> Addresses { get; init; }

        public static Partner None => new()
        {
            Name = string.Empty,
            Phone = string.Empty,
            Email = string.Empty,
            Description = string.Empty,
            Addresses = null
        };

        public Partner()
        {
            Addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));

            Addresses.Add(address);
        }

        public bool RemoveAddress(Address address)
        {
            return Addresses.Remove(address);
        }

        public bool RemoveAddress(Guid id)
        {
            var address = Addresses.SingleOrDefault(a => a.Id == id);
            return address != null && Addresses.Remove(address);
        }
    }
}
