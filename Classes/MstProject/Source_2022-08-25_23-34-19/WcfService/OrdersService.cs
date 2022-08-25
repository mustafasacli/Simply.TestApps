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
    public class OrdersService : IOrdersService
    {
        private IOrdersBusiness iOrdersBusiness;

        public OrdersService()
        {
            this.iOrdersBusiness =
                SimpleIoC.Instance.GetInstance<IOrdersBusiness>();
        }

        public SimpleResponse<OrdersDto> Create(OrdersDto dto)
        {
            var response = new SimpleResponse<OrdersDto>();

            try
            {
                var model = SimpleMapper.Map<OrdersDto, OrdersViewModel>(dto);
                var resp = iOrdersBusiness.Create(model);
                response = new SimpleResponse<OrdersDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<OrdersViewModel, OrdersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<OrdersDto> Read(int orderNumber)
        {
            var response = new SimpleResponse<OrdersDto>();

            try
            {
                var resp  = iOrdersBusiness.Read(orderNumber);
                var isNullOrDef = resp.Data == null || resp.Data == default(OrdersViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<OrdersViewModel, OrdersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(OrdersDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OrdersDto, OrdersViewModel>(dto);
                response = iOrdersBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(OrdersDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OrdersDto, OrdersViewModel>(dto);
                response = iOrdersBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int orderNumber)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iOrdersBusiness.Delete(orderNumber);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<OrdersDto>> ReadAll()
        {
            var response = new SimpleResponse<List<OrdersDto>>();

            try
            {
                var resp = iOrdersBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<OrdersViewModel, OrdersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<OrdersDto>();
            return response;
        }
    }
}