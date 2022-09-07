using Management.Partners.Domain.Base;
using Management.Partners.Domain.Interfaces;

namespace Management.Partners.Domain.Entities
{
    public record Partner : BaseEntity, IAggregateRoot
    {
        public string Name { get; private init; }

        public string Description { get; private init; }

        public List<Address> Addresses { get; private init; } = new List<Address>();

        public Partner(string name, string description) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Addresses = new List<Address>();
        }

        public Partner Update(string name, string desciption)
        {
            return new(name, desciption);
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
