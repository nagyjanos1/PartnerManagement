using AutoMapper;
using Management.Partners.Domain.Partners;

namespace Management.Partners.Infrastructure.Configurations
{
    internal class InfrastuctureMapperConfig : Profile
    {
        public InfrastuctureMapperConfig()
        {
            CreateMap<Partner, Entities.Partner>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ReverseMap()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<Address, Entities.Address>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ReverseMap()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
