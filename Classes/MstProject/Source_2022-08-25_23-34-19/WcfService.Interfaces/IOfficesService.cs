using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/OfficesService")]
    public interface IOfficesService
    {
        [OperationContract]
        SimpleResponse<OfficesDto> Create(OfficesDto dto);

        [OperationContract]
        SimpleResponse<OfficesDto> Read(string officeCode);

        [OperationContract]
        SimpleResponse Update(OfficesDto dto);

        [OperationContract]
        SimpleResponse Delete(OfficesDto dto);

        [OperationContract]
        SimpleResponse Delete(string officeCode);

        [OperationContract]
        SimpleResponse<List<OfficesDto>> ReadAll();
    }
}