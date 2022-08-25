using AutoMapper;

namespace Mst.Project.Mapping
{
    public class CustomersMapperProfile : Profile
    {
        public CustomersMapperProfileProfile()
        {
            CreateMap<Customers, CustomersDto>()
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber)
                .ForMember(destination => destination.CustomerName, source => source.CustomerName)
                .ForMember(destination => destination.ContactLastName, source => source.ContactLastName)
                .ForMember(destination => destination.ContactFirstName, source => source.ContactFirstName)
                .ForMember(destination => destination.Phone, source => source.Phone)
                .ForMember(destination => destination.AddressLine1, source => source.AddressLine1)
                .ForMember(destination => destination.AddressLine2, source => source.AddressLine2)
                .ForMember(destination => destination.City, source => source.City)
                .ForMember(destination => destination.State, source => source.State)
                .ForMember(destination => destination.PostalCode, source => source.PostalCode)
                .ForMember(destination => destination.Country, source => source.Country)
                .ForMember(destination => destination.SalesRepEmployeeNumber, source => source.SalesRepEmployeeNumber)
                .ForMember(destination => destination.CreditLimit, source => source.CreditLimit);

            CreateMap<Customers, CustomersViewModel>()
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber)
                .ForMember(destination => destination.CustomerName, source => source.CustomerName)
                .ForMember(destination => destination.ContactLastName, source => source.ContactLastName)
                .ForMember(destination => destination.ContactFirstName, source => source.ContactFirstName)
                .ForMember(destination => destination.Phone, source => source.Phone)
                .ForMember(destination => destination.AddressLine1, source => source.AddressLine1)
                .ForMember(destination => destination.AddressLine2, source => source.AddressLine2)
                .ForMember(destination => destination.City, source => source.City)
                .ForMember(destination => destination.State, source => source.State)
                .ForMember(destination => destination.PostalCode, source => source.PostalCode)
                .ForMember(destination => destination.Country, source => source.Country)
                .ForMember(destination => destination.SalesRepEmployeeNumber, source => source.SalesRepEmployeeNumber)
                .ForMember(destination => destination.CreditLimit, source => source.CreditLimit);
        }
    }
}