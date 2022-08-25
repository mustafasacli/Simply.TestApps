using AutoMapper;

namespace Mst.Project.Mapping
{
    public class OrdersMapperProfile : Profile
    {
        public OrdersMapperProfileProfile()
        {
            CreateMap<Orders, OrdersDto>()
                .ForMember(destination => destination.OrderNumber, source => source.OrderNumber)
                .ForMember(destination => destination.OrderDate, source => source.OrderDate)
                .ForMember(destination => destination.RequiredDate, source => source.RequiredDate)
                .ForMember(destination => destination.ShippedDate, source => source.ShippedDate)
                .ForMember(destination => destination.Status, source => source.Status)
                .ForMember(destination => destination.Comments, source => source.Comments)
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber);

            CreateMap<Orders, OrdersViewModel>()
                .ForMember(destination => destination.OrderNumber, source => source.OrderNumber)
                .ForMember(destination => destination.OrderDate, source => source.OrderDate)
                .ForMember(destination => destination.RequiredDate, source => source.RequiredDate)
                .ForMember(destination => destination.ShippedDate, source => source.ShippedDate)
                .ForMember(destination => destination.Status, source => source.Status)
                .ForMember(destination => destination.Comments, source => source.Comments)
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber);
        }
    }
}