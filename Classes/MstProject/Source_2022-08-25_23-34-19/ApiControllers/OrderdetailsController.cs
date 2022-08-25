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
    public class OrderdetailsController : ApiController
    {
        private IOrderdetailsBusiness iOrderdetailsBusiness;

        public OrderdetailsController(IOrderdetailsBusiness iOrderdetailsBusiness = null)
        {
            this.iOrderdetailsBusiness = iOrderdetailsBusiness ?? 
                GsbIoC.Instance.GetInstance<IOrderdetailsBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(OrderdetailsViewModel model)
        {
            var response = new SimpleResponse<OrderdetailsViewModel>();
            response = iOrderdetailsBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int orderNumber, string productCode)
        {
            var modelResult = iOrderdetailsBusiness.Read(orderNumber, productCode);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(OrderdetailsViewModel model)
        {
            var response = new SimpleResponse();
            response = iOrderdetailsBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int orderNumber, string productCode)
        {
            var result = iOrderdetailsBusiness.Delete(orderNumber, productCode);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iOrderdetailsBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}