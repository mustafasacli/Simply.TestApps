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
    public class OrdersController : ApiController
    {
        private IOrdersBusiness iOrdersBusiness;

        public OrdersController(IOrdersBusiness iOrdersBusiness = null)
        {
            this.iOrdersBusiness = iOrdersBusiness ?? 
                GsbIoC.Instance.GetInstance<IOrdersBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(OrdersViewModel model)
        {
            var response = new SimpleResponse<OrdersViewModel>();
            response = iOrdersBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int orderNumber)
        {
            var modelResult = iOrdersBusiness.Read(orderNumber);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(OrdersViewModel model)
        {
            var response = new SimpleResponse();
            response = iOrdersBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int orderNumber)
        {
            var result = iOrdersBusiness.Delete(orderNumber);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iOrdersBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}