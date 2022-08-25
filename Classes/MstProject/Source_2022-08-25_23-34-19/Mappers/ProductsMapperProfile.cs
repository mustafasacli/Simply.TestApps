using AutoMapper;

namespace Mst.Project.Mapping
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfileProfile()
        {
            CreateMap<Products, ProductsDto>()
                .ForMember(destination => destination.ProductCode, source => source.ProductCode)
                .ForMember(destination => destination.ProductName, source => source.ProductName)
                .ForMember(destination => destination.ProductLine, source => source.ProductLine)
                .ForMember(destination => destination.ProductScale, source => source.ProductScale)
                .ForMember(destination => destination.ProductVendor, source => source.ProductVendor)
                .ForMember(destination => destination.ProductDescription, source => source.ProductDescription)
                .ForMember(destination => destination.QuantityInStock, source => source.QuantityInStock)
                .ForMember(destination => destination.BuyPrice, source => source.BuyPrice)
                .ForMember(destination => destination.Msrp, source => source.Msrp);

            CreateMap<Products, ProductsViewModel>()
                .ForMember(destination => destination.ProductCode, source => source.ProductCode)
                .ForMember(destination => destination.ProductName, source => source.ProductName)
                .ForMember(destination => destination.ProductLine, source => source.ProductLine)
                .ForMember(destination => destination.ProductScale, source => source.ProductScale)
                .ForMember(destination => destination.ProductVendor, source => source.ProductVendor)
                .ForMember(destination => destination.ProductDescription, source => source.ProductDescription)
                .ForMember(destination => destination.QuantityInStock, source => source.QuantityInStock)
                .ForMember(destination => destination.BuyPrice, source => source.BuyPrice)
                .ForMember(destination => destination.Msrp, source => source.Msrp);
        }
    }
}