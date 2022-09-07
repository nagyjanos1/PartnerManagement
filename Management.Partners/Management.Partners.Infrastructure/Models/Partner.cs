using Management.Partners.Infrastructure.Base;

namespace Management.Partners.Infrastructure.Models
{
    internal class Partner : BaseModel
    { 
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public Partner() => Addresses = new HashSet<Address>();
    }
}