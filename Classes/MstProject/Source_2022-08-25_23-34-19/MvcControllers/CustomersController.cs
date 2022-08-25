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
    public class CustomersController : OzelYurtBaseController
    {
        private ICustomersBusiness iCustomersBusiness;

        public CustomersController(ICustomersBusiness iCustomersBusiness = null)
        {
            this.iCustomersBusiness = iCustomersBusiness ??
                GsbIoC.Instance.GetInstance<ICustomersBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iCustomersBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new CustomersViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(CustomersViewModel model)
        {
            var response = iCustomersBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(CustomersViewModel model)
        {
            var response = iCustomersBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int customerNumber)
        {
            var response = iCustomersBusiness.Delete(customerNumber);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerNumber });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iCustomersBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}