using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/PaymentsService")]
    public interface IPaymentsService
    {
        [OperationContract]
        SimpleResponse<PaymentsDto> Create(PaymentsDto dto);

        [OperationContract]
        SimpleResponse<PaymentsDto> Read(int customerNumber, string checkNumber);

        [OperationContract]
        SimpleResponse Update(PaymentsDto dto);

        [OperationContract]
        SimpleResponse Delete(PaymentsDto dto);

        [OperationContract]
        SimpleResponse Delete(int customerNumber, string checkNumber);

        [OperationContract]
        SimpleResponse<List<PaymentsDto>> ReadAll();
    }
}