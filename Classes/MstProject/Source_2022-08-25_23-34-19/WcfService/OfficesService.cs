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
    public class OfficesService : IOfficesService
    {
        private IOfficesBusiness iOfficesBusiness;

        public OfficesService()
        {
            this.iOfficesBusiness =
                SimpleIoC.Instance.GetInstance<IOfficesBusiness>();
        }

        public SimpleResponse<OfficesDto> Create(OfficesDto dto)
        {
            var response = new SimpleResponse<OfficesDto>();

            try
            {
                var model = SimpleMapper.Map<OfficesDto, OfficesViewModel>(dto);
                var resp = iOfficesBusiness.Create(model);
                response = new SimpleResponse<OfficesDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<OfficesViewModel, OfficesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<OfficesDto> Read(string officeCode)
        {
            var response = new SimpleResponse<OfficesDto>();

            try
            {
                var resp  = iOfficesBusiness.Read(officeCode);
                var isNullOrDef = resp.Data == null || resp.Data == default(OfficesViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<OfficesViewModel, OfficesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(OfficesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OfficesDto, OfficesViewModel>(dto);
                response = iOfficesBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(OfficesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<OfficesDto, OfficesViewModel>(dto);
                response = iOfficesBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(string officeCode)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iOfficesBusiness.Delete(officeCode);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<OfficesDto>> ReadAll()
        {
            var response = new SimpleResponse<List<OfficesDto>>();

            try
            {
                var resp = iOfficesBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<OfficesViewModel, OfficesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<OfficesDto>();
            return response;
        }
    }
}