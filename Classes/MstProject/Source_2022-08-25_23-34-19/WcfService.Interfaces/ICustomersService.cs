using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/CustomersService")]
    public interface ICustomersService
    {
        [OperationContract]
        SimpleResponse<CustomersDto> Create(CustomersDto dto);

        [OperationContract]
        SimpleResponse<CustomersDto> Read(int customerNumber);

        [OperationContract]
        SimpleResponse Update(CustomersDto dto);

        [OperationContract]
        SimpleResponse Delete(CustomersDto dto);

        [OperationContract]
        SimpleResponse Delete(int customerNumber);

        [OperationContract]
        SimpleResponse<List<CustomersDto>> ReadAll();
    }
}