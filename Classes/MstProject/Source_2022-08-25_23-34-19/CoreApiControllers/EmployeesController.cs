using Mst.Project.Business.Interfaces;
using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mst.Project.CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesBusiness iEmployeesBusiness;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger,
                    IEmployeesBusiness iEmployeesBusiness)
        {
            this._logger = logger;
            this.iEmployeesBusiness = iEmployeesBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<EmployeesViewModel> Create(EmployeesViewModel model)
        {
            var response = iEmployeesBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<EmployeesViewModel> Detail(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(EmployeesViewModel model)
        {
            var response = iEmployeesBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int employeeNumber)
        {
            var result = iEmployeesBusiness.Delete(employeeNumber);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<EmployeesViewModel>> ReadAll()
        {
            var response = iEmployeesBusiness.ReadAll();
            return response;
        }
    }
}