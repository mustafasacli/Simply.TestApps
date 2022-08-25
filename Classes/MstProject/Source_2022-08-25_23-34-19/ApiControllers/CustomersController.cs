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
    public class CustomersController : ApiController
    {
        private ICustomersBusiness iCustomersBusiness;

        public CustomersController(ICustomersBusiness iCustomersBusiness = null)
        {
            this.iCustomersBusiness = iCustomersBusiness ?? 
                GsbIoC.Instance.GetInstance<ICustomersBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(CustomersViewModel model)
        {
            var response = new SimpleResponse<CustomersViewModel>();
            response = iCustomersBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int customerNumber)
        {
            var modelResult = iCustomersBusiness.Read(customerNumber);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(CustomersViewModel model)
        {
            var response = new SimpleResponse();
            response = iCustomersBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int customerNumber)
        {
            var result = iCustomersBusiness.Delete(customerNumber);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iCustomersBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}