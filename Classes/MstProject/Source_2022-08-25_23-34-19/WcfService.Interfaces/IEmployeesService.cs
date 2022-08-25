using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/EmployeesService")]
    public interface IEmployeesService
    {
        [OperationContract]
        SimpleResponse<EmployeesDto> Create(EmployeesDto dto);

        [OperationContract]
        SimpleResponse<EmployeesDto> Read(int employeeNumber);

        [OperationContract]
        SimpleResponse Update(EmployeesDto dto);

        [OperationContract]
        SimpleResponse Delete(EmployeesDto dto);

        [OperationContract]
        SimpleResponse Delete(int employeeNumber);

        [OperationContract]
        SimpleResponse<List<EmployeesDto>> ReadAll();
    }
}