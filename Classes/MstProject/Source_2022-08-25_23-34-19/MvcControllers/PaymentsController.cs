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
    public class PaymentsController : OzelYurtBaseController
    {
        private IPaymentsBusiness iPaymentsBusiness;

        public PaymentsController(IPaymentsBusiness iPaymentsBusiness = null)
        {
            this.iPaymentsBusiness = iPaymentsBusiness ??
                GsbIoC.Instance.GetInstance<IPaymentsBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iPaymentsBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new PaymentsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(PaymentsViewModel model)
        {
            var response = iPaymentsBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(PaymentsViewModel model)
        {
            var response = iPaymentsBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Delete(customerNumber, checkNumber);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerNumber, checkNumber });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iPaymentsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}