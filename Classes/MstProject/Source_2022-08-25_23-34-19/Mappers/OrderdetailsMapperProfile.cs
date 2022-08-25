using AutoMapper;

namespace Mst.Project.Mapping
{
    public class OrderdetailsMapperProfile : Profile
    {
        public OrderdetailsMapperProfileProfile()
        {
            CreateMap<Orderdetails, OrderdetailsDto>()
                .ForMember(destination => destination.OrderNumber, source => source.OrderNumber)
                .ForMember(destination => destination.ProductCode, source => source.ProductCode)
                .ForMember(destination => destination.QuantityOrdered, source => source.QuantityOrdered)
                .ForMember(destination => destination.PriceEach, source => source.PriceEach)
                .ForMember(destination => destination.OrderLineNumber, source => source.OrderLineNumber);

            CreateMap<Orderdetails, OrderdetailsViewModel>()
                .ForMember(destination => destination.OrderNumber, source => source.OrderNumber)
                .ForMember(destination => destination.ProductCode, source => source.ProductCode)
                .ForMember(destination => destination.QuantityOrdered, source => source.QuantityOrdered)
                .ForMember(destination => destination.PriceEach, source => source.PriceEach)
                .ForMember(destination => destination.OrderLineNumber, source => source.OrderLineNumber);
        }
    }
}