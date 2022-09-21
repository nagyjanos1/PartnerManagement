using AutoMapper;
using Management.Partners.Domain.Partners;

namespace Management.Partners.Infrastructure.Configurations
{
    internal class InfrastuctureMapperConfig : Profile
    {
        public InfrastuctureMapperConfig()
        {
            CreateMap<Partner, Entities.Partner>()
                .ReverseMap();

            CreateMap<Address, Entities.Address>()
                .ReverseMap();
        }
    }
}
