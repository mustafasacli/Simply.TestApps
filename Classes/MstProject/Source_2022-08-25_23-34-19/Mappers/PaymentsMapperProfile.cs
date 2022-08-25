using AutoMapper;

namespace Mst.Project.Mapping
{
    public class PaymentsMapperProfile : Profile
    {
        public PaymentsMapperProfileProfile()
        {
            CreateMap<Payments, PaymentsDto>()
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber)
                .ForMember(destination => destination.CheckNumber, source => source.CheckNumber)
                .ForMember(destination => destination.PaymentDate, source => source.PaymentDate)
                .ForMember(destination => destination.Amount, source => source.Amount);

            CreateMap<Payments, PaymentsViewModel>()
                .ForMember(destination => destination.CustomerNumber, source => source.CustomerNumber)
                .ForMember(destination => destination.CheckNumber, source => source.CheckNumber)
                .ForMember(destination => destination.PaymentDate, source => source.PaymentDate)
                .ForMember(destination => destination.Amount, source => source.Amount);
        }
    }
}