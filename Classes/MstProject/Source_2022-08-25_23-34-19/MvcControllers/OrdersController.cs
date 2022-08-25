using Mst.Project.Business.Interfaces;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Core;
using Gsb.IoC;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Mst.Project.Web.Controllers
{
    public class OrdersController : OzelYurtBaseController
    {
        private IOrdersBusiness iOrdersBusiness;

        public OrdersController(IOrdersBusiness iOrdersBusiness = null)
        {
            this.iOrdersBusiness = iOrdersBusiness ??
                GsbIoC.Instance.GetInstance<IOrdersBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iOrdersBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new OrdersViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(OrdersViewModel model)
        {
            var response = iOrdersBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(OrdersViewModel model)
        {
            var response = iOrdersBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int orderNumber)
        {
            var response = iOrdersBusiness.Delete(orderNumber);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { orderNumber });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iOrdersBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}