using Mst.Project.Dtos;
using Mst.Project.Business.Interfaces;
using Mst.Project.WcfService.Interfaces;
using Mst.Project.ViewModel;
using SimpleFileLogging;
using SimpleInfra.Business.Core;
using SimpleInfra.Common.Core;
using SimpleInfra.IoC;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mst.Project.WcfService
{
    public class ProductsService : IProductsService
    {
        private IProductsBusiness iProductsBusiness;

        public ProductsService()
        {
            this.iProductsBusiness =
                SimpleIoC.Instance.GetInstance<IProductsBusiness>();
        }

        public SimpleResponse<ProductsDto> Create(ProductsDto dto)
        {
            var response = new SimpleResponse<ProductsDto>();

            try
            {
                var model = SimpleMapper.Map<ProductsDto, ProductsViewModel>(dto);
                var resp = iProductsBusiness.Create(model);
                response = new SimpleResponse<ProductsDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ProductsViewModel, ProductsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ProductsDto> Read(string productCode)
        {
            var response = new SimpleResponse<ProductsDto>();

            try
            {
                var resp  = iProductsBusiness.Read(productCode);
                var isNullOrDef = resp.Data == null || resp.Data == default(ProductsViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ProductsViewModel, ProductsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ProductsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ProductsDto, ProductsViewModel>(dto);
                response = iProductsBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ProductsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ProductsDto, ProductsViewModel>(dto);
                response = iProductsBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(string productCode)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iProductsBusiness.Delete(productCode);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ProductsDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ProductsDto>>();

            try
            {
                var resp = iProductsBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ProductsViewModel, ProductsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ProductsDto>();
            return response;
        }
    }
}