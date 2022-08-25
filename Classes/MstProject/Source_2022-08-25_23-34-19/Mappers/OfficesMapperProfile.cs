using AutoMapper;

namespace Mst.Project.Mapping
{
    public class OfficesMapperProfile : Profile
    {
        public OfficesMapperProfileProfile()
        {
            CreateMap<Offices, OfficesDto>()
                .ForMember(destination => destination.OfficeCode, source => source.OfficeCode)
                .ForMember(destination => destination.City, source => source.City)
                .ForMember(destination => destination.Phone, source => source.Phone)
                .ForMember(destination => destination.AddressLine1, source => source.AddressLine1)
                .ForMember(destination => destination.AddressLine2, source => source.AddressLine2)
                .ForMember(destination => destination.State, source => source.State)
                .ForMember(destination => destination.Country, source => source.Country)
                .ForMember(destination => destination.PostalCode, source => source.PostalCode)
                .ForMember(destination => destination.Territory, source => source.Territory);

            CreateMap<Offices, OfficesViewModel>()
                .ForMember(destination => destination.OfficeCode, source => source.OfficeCode)
                .ForMember(destination => destination.City, source => source.City)
                .ForMember(destination => destination.Phone, source => source.Phone)
                .ForMember(destination => destination.AddressLine1, source => source.AddressLine1)
                .ForMember(destination => destination.AddressLine2, source => source.AddressLine2)
                .ForMember(destination => destination.State, source => source.State)
                .ForMember(destination => destination.Country, source => source.Country)
                .ForMember(destination => destination.PostalCode, source => source.PostalCode)
                .ForMember(destination => destination.Territory, source => source.Territory);
        }
    }
}