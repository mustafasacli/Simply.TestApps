using AutoMapper;

namespace Mst.Project.Mapping
{
    public class ProductlinesMapperProfile : Profile
    {
        public ProductlinesMapperProfileProfile()
        {
            CreateMap<Productlines, ProductlinesDto>()
                .ForMember(destination => destination.ProductLine, source => source.ProductLine)
                .ForMember(destination => destination.TextDescription, source => source.TextDescription)
                .ForMember(destination => destination.HtmlDescription, source => source.HtmlDescription)
                .ForMember(destination => destination.Image, source => source.Image);

            CreateMap<Productlines, ProductlinesViewModel>()
                .ForMember(destination => destination.ProductLine, source => source.ProductLine)
                .ForMember(destination => destination.TextDescription, source => source.TextDescription)
                .ForMember(destination => destination.HtmlDescription, source => source.HtmlDescription)
                .ForMember(destination => destination.Image, source => source.Image);
        }
    }
}