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
    public class CustomersController : ControllerBase
    {
        private ICustomersBusiness iCustomersBusiness;

        public CustomersController(ICustomersBusiness iCustomersBusiness)
        {
            this.iCustomersBusiness = iCustomersBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iCustomersBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CustomersViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CustomersViewModel model)
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
        public IActionResult Detail(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(CustomersViewModel model)
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

        public IActionResult Delete(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int customerNumber)
        {
            var response = iCustomersBusiness.Delete(customerNumber);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerNumber });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iCustomersBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}