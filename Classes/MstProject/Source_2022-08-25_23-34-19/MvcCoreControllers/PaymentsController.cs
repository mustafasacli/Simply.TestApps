using Mst.Project.Business.Interfaces;
using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Mst.Project.Web.Controllers
{
    public class PaymentsController : ControllerBase
    {
        private IPaymentsBusiness iPaymentsBusiness;

        public PaymentsController(IPaymentsBusiness iPaymentsBusiness)
        {
            this.iPaymentsBusiness = iPaymentsBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iPaymentsBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new PaymentsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(PaymentsViewModel model)
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
        public IActionResult Detail(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(PaymentsViewModel model)
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

        public IActionResult Delete(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Delete(customerNumber, checkNumber);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerNumber, checkNumber });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iPaymentsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}