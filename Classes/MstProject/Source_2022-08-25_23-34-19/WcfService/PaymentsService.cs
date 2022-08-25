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
    public class PaymentsService : IPaymentsService
    {
        private IPaymentsBusiness iPaymentsBusiness;

        public PaymentsService()
        {
            this.iPaymentsBusiness =
                SimpleIoC.Instance.GetInstance<IPaymentsBusiness>();
        }

        public SimpleResponse<PaymentsDto> Create(PaymentsDto dto)
        {
            var response = new SimpleResponse<PaymentsDto>();

            try
            {
                var model = SimpleMapper.Map<PaymentsDto, PaymentsViewModel>(dto);
                var resp = iPaymentsBusiness.Create(model);
                response = new SimpleResponse<PaymentsDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<PaymentsViewModel, PaymentsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<PaymentsDto> Read(int customerNumber, string checkNumber)
        {
            var response = new SimpleResponse<PaymentsDto>();

            try
            {
                var resp  = iPaymentsBusiness.Read(customerNumber, checkNumber);
                var isNullOrDef = resp.Data == null || resp.Data == default(PaymentsViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<PaymentsViewModel, PaymentsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(PaymentsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<PaymentsDto, PaymentsViewModel>(dto);
                response = iPaymentsBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(PaymentsDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<PaymentsDto, PaymentsViewModel>(dto);
                response = iPaymentsBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int customerNumber, string checkNumber)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iPaymentsBusiness.Delete(customerNumber, checkNumber);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<PaymentsDto>> ReadAll()
        {
            var response = new SimpleResponse<List<PaymentsDto>>();

            try
            {
                var resp = iPaymentsBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<PaymentsViewModel, PaymentsDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<PaymentsDto>();
            return response;
        }
    }
}