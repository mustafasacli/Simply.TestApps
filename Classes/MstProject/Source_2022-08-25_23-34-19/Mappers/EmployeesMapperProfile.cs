using AutoMapper;

namespace Mst.Project.Mapping
{
    public class EmployeesMapperProfile : Profile
    {
        public EmployeesMapperProfileProfile()
        {
            CreateMap<Employees, EmployeesDto>()
                .ForMember(destination => destination.EmployeeNumber, source => source.EmployeeNumber)
                .ForMember(destination => destination.LastName, source => source.LastName)
                .ForMember(destination => destination.FirstName, source => source.FirstName)
                .ForMember(destination => destination.Extension, source => source.Extension)
                .ForMember(destination => destination.Email, source => source.Email)
                .ForMember(destination => destination.OfficeCode, source => source.OfficeCode)
                .ForMember(destination => destination.ReportsTo, source => source.ReportsTo)
                .ForMember(destination => destination.JobTitle, source => source.JobTitle);

            CreateMap<Employees, EmployeesViewModel>()
                .ForMember(destination => destination.EmployeeNumber, source => source.EmployeeNumber)
                .ForMember(destination => destination.LastName, source => source.LastName)
                .ForMember(destination => destination.FirstName, source => source.FirstName)
                .ForMember(destination => destination.Extension, source => source.Extension)
                .ForMember(destination => destination.Email, source => source.Email)
                .ForMember(destination => destination.OfficeCode, source => source.OfficeCode)
                .ForMember(destination => destination.ReportsTo, source => source.ReportsTo)
                .ForMember(destination => destination.JobTitle, source => source.JobTitle);
        }
    }
}