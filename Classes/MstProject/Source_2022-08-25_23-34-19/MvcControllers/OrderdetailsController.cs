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
    public class OrderdetailsController : OzelYurtBaseController
    {
        private IOrderdetailsBusiness iOrderdetailsBusiness;

        public OrderdetailsController(IOrderdetailsBusiness iOrderdetailsBusiness = null)
        {
            this.iOrderdetailsBusiness = iOrderdetailsBusiness ??
                GsbIoC.Instance.GetInstance<IOrderdetailsBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iOrderdetailsBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new OrderdetailsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(OrderdetailsViewModel model)
        {
            var response = iOrderdetailsBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(OrderdetailsViewModel model)
        {
            var response = iOrderdetailsBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Delete(orderNumber, productCode);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { orderNumber, productCode });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iOrderdetailsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}