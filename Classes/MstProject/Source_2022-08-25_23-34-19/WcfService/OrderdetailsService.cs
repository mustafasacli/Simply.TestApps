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
    public class OrderdetailsService : IOrderdetailsService
    {
        private IOrderdetailsBusiness iOrderdetailsBusiness;

        public OrderdetailsService()
        {
            this.iOrderdetailsBusiness =
                SimpleIoC.Instance.GetInstance<IOrderdetailsBusiness>();
        }

        public SimpleResponse<OrderdetailsDto> Create(OrderdetailsDto dto)
        {
            var response = new SimpleResponse<OrderdetailsDto>();

            try
            {
                var model = SimpleMapper.Map<OrderdetailsDto, OrderdetailsViewModel>(dto);
                var resp = iOrderdetailsBusiness.Create(model);
                response = new SimpleResponse<OrderdetailsDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<OrderdetailsViewModel, OrderdetailsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<OrderdetailsDto> Read(int orderNumber, string productCode)
        {
            var response = new SimpleResponse<OrderdetailsDto>();

            try
            {
                var resp  = iOrderdetailsBusiness.Read(orderNumber, productCode);
                var isNullOrDef = resp.Data == null || resp.Data == default(OrderdetailsViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<OrderdetailsViewModel, OrderdetailsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(OrderdetailsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OrderdetailsDto, OrderdetailsViewModel>(dto);
                response = iOrderdetailsBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(OrderdetailsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OrderdetailsDto, OrderdetailsViewModel>(dto);
                response = iOrderdetailsBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int orderNumber, string productCode)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iOrderdetailsBusiness.Delete(orderNumber, productCode);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<OrderdetailsDto>> ReadAll()
        {
            var response = new SimpleResponse<List<OrderdetailsDto>>();

            try
            {
                var resp = iOrderdetailsBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<OrderdetailsViewModel, OrderdetailsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<OrderdetailsDto>();
            return response;
        }
    }
}