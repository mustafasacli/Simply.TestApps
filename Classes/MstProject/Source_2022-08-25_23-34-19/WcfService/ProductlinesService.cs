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
    public class ProductlinesService : IProductlinesService
    {
        private IProductlinesBusiness iProductlinesBusiness;

        public ProductlinesService()
        {
            this.iProductlinesBusiness =
                SimpleIoC.Instance.GetInstance<IProductlinesBusiness>();
        }

        public SimpleResponse<ProductlinesDto> Create(ProductlinesDto dto)
        {
            var response = new SimpleResponse<ProductlinesDto>();

            try
            {
                var model = SimpleMapper.Map<ProductlinesDto, ProductlinesViewModel>(dto);
                var resp = iProductlinesBusiness.Create(model);
                response = new SimpleResponse<ProductlinesDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ProductlinesViewModel, ProductlinesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ProductlinesDto> Read(string productLine)
        {
            var response = new SimpleResponse<ProductlinesDto>();

            try
            {
                var resp  = iProductlinesBusiness.Read(productLine);
                var isNullOrDef = resp.Data == null || resp.Data == default(ProductlinesViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ProductlinesViewModel, ProductlinesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ProductlinesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ProductlinesDto, ProductlinesViewModel>(dto);
                response = iProductlinesBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ProductlinesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ProductlinesDto, ProductlinesViewModel>(dto);
                response = iProductlinesBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(string productLine)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iProductlinesBusiness.Delete(productLine);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ProductlinesDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ProductlinesDto>>();

            try
            {
                var resp = iProductlinesBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ProductlinesViewModel, ProductlinesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ProductlinesDto>();
            return response;
        }
    }
}