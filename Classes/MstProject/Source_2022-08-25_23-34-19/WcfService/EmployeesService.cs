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
    public class EmployeesService : IEmployeesService
    {
        private IEmployeesBusiness iEmployeesBusiness;

        public EmployeesService()
        {
            this.iEmployeesBusiness =
                SimpleIoC.Instance.GetInstance<IEmployeesBusiness>();
        }

        public SimpleResponse<EmployeesDto> Create(EmployeesDto dto)
        {
            var response = new SimpleResponse<EmployeesDto>();

            try
            {
                var model = SimpleMapper.Map<EmployeesDto, EmployeesViewModel>(dto);
                var resp = iEmployeesBusiness.Create(model);
                response = new SimpleResponse<EmployeesDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<EmployeesViewModel, EmployeesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<EmployeesDto> Read(int employeeNumber)
        {
            var response = new SimpleResponse<EmployeesDto>();

            try
            {
                var resp  = iEmployeesBusiness.Read(employeeNumber);
                var isNullOrDef = resp.Data == null || resp.Data == default(EmployeesViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<EmployeesViewModel, EmployeesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(EmployeesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<EmployeesDto, EmployeesViewModel>(dto);
                response = iEmployeesBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(EmployeesDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<EmployeesDto, EmployeesViewModel>(dto);
                response = iEmployeesBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int employeeNumber)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iEmployeesBusiness.Delete(employeeNumber);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<EmployeesDto>> ReadAll()
        {
            var response = new SimpleResponse<List<EmployeesDto>>();

            try
            {
                var resp = iEmployeesBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<EmployeesViewModel, EmployeesDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<EmployeesDto>();
            return response;
        }
    }
}