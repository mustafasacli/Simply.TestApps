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
    public class PaymentsController : ApiController
    {
        private IPaymentsBusiness iPaymentsBusiness;

        public PaymentsController(IPaymentsBusiness iPaymentsBusiness = null)
        {
            this.iPaymentsBusiness = iPaymentsBusiness ?? 
                GsbIoC.Instance.GetInstance<IPaymentsBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(PaymentsViewModel model)
        {
            var response = new SimpleResponse<PaymentsViewModel>();
            response = iPaymentsBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int customerNumber, string checkNumber)
        {
            var modelResult = iPaymentsBusiness.Read(customerNumber, checkNumber);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(PaymentsViewModel model)
        {
            var response = new SimpleResponse();
            response = iPaymentsBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int customerNumber, string checkNumber)
        {
            var result = iPaymentsBusiness.Delete(customerNumber, checkNumber);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iPaymentsBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}