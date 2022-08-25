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
    public class CustomersService : ICustomersService
    {
        private ICustomersBusiness iCustomersBusiness;

        public CustomersService()
        {
            this.iCustomersBusiness =
                SimpleIoC.Instance.GetInstance<ICustomersBusiness>();
        }

        public SimpleResponse<CustomersDto> Create(CustomersDto dto)
        {
            var response = new SimpleResponse<CustomersDto>();

            try
            {
                var model = SimpleMapper.Map<CustomersDto, CustomersViewModel>(dto);
                var resp = iCustomersBusiness.Create(model);
                response = new SimpleResponse<CustomersDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<CustomersViewModel, CustomersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<CustomersDto> Read(int customerNumber)
        {
            var response = new SimpleResponse<CustomersDto>();

            try
            {
                var resp  = iCustomersBusiness.Read(customerNumber);
                var isNullOrDef = resp.Data == null || resp.Data == default(CustomersViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<CustomersViewModel, CustomersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(CustomersDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CustomersDto, CustomersViewModel>(dto);
                response = iCustomersBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(CustomersDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CustomersDto, CustomersViewModel>(dto);
                response = iCustomersBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int customerNumber)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iCustomersBusiness.Delete(customerNumber);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<CustomersDto>> ReadAll()
        {
            var response = new SimpleResponse<List<CustomersDto>>();

            try
            {
                var resp = iCustomersBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<CustomersViewModel, CustomersDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<CustomersDto>();
            return response;
        }
    }
}