using Mst.Project.ViewModel;
using Mst.Project.Business.Interfaces;
using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using SimpleInfra.Common.Core;
using Gsb.IoC;
using SimpleInfra.Validation;
using SimpleInfra.Mapping;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Mst.Project.Web.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeesBusiness iEmployeesBusiness;

        public EmployeesController(IEmployeesBusiness iEmployeesBusiness = null)
        {
            this.iEmployeesBusiness = iEmployeesBusiness ?? 
                GsbIoC.Instance.GetInstance<IEmployeesBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(EmployeesViewModel model)
        {
            var response = new SimpleResponse<EmployeesViewModel>();
            response = iEmployeesBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int employeeNumber)
        {
            var modelResult = iEmployeesBusiness.Read(employeeNumber);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(EmployeesViewModel model)
        {
            var response = new SimpleResponse();
            response = iEmployeesBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int employeeNumber)
        {
            var result = iEmployeesBusiness.Delete(employeeNumber);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iEmployeesBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}