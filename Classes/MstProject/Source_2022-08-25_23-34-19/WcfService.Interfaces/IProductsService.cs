using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Mst.Project.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ProductsService")]
    public interface IProductsService
    {
        [OperationContract]
        SimpleResponse<ProductsDto> Create(ProductsDto dto);

        [OperationContract]
        SimpleResponse<ProductsDto> Read(string productCode);

        [OperationContract]
        SimpleResponse Update(ProductsDto dto);

        [OperationContract]
        SimpleResponse Delete(ProductsDto dto);

        [OperationContract]
        SimpleResponse Delete(string productCode);

        [OperationContract]
        SimpleResponse<List<ProductsDto>> ReadAll();
    }
}