using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/OrdersService")]
    public interface IOrdersService
    {
        [OperationContract]
        SimpleResponse<OrdersDto> Create(OrdersDto dto);

        [OperationContract]
        SimpleResponse<OrdersDto> Read(int orderNumber);

        [OperationContract]
        SimpleResponse Update(OrdersDto dto);

        [OperationContract]
        SimpleResponse Delete(OrdersDto dto);

        [OperationContract]
        SimpleResponse Delete(int orderNumber);

        [OperationContract]
        SimpleResponse<List<OrdersDto>> ReadAll();
    }
}