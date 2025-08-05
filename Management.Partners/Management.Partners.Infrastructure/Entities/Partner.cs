using Management.Partners.Infrastructure.Base;

namespace Management.Partners.Infrastructure.Entities;

internal class Partner : BaseEntity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }

    public Partner() => Addresses = new HashSet<Address>();
}