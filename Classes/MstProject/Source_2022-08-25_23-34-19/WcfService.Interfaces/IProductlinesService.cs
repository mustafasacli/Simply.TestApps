using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ProductlinesService")]
    public interface IProductlinesService
    {
        [OperationContract]
        SimpleResponse<ProductlinesDto> Create(ProductlinesDto dto);

        [OperationContract]
        SimpleResponse<ProductlinesDto> Read(string productLine);

        [OperationContract]
        SimpleResponse Update(ProductlinesDto dto);

        [OperationContract]
        SimpleResponse Delete(ProductlinesDto dto);

        [OperationContract]
        SimpleResponse Delete(string productLine);

        [OperationContract]
        SimpleResponse<List<ProductlinesDto>> ReadAll();
    }
}