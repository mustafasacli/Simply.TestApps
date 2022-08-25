using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/OrderdetailsService")]
    public interface IOrderdetailsService
    {
        [OperationContract]
        SimpleResponse<OrderdetailsDto> Create(OrderdetailsDto dto);

        [OperationContract]
        SimpleResponse<OrderdetailsDto> Read(int orderNumber, string productCode);

        [OperationContract]
        SimpleResponse Update(OrderdetailsDto dto);

        [OperationContract]
        SimpleResponse Delete(OrderdetailsDto dto);

        [OperationContract]
        SimpleResponse Delete(int orderNumber, string productCode);

        [OperationContract]
        SimpleResponse<List<OrderdetailsDto>> ReadAll();
    }
}