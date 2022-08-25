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
    public class OrderdetailsController : ControllerBase
    {
        private IOrderdetailsBusiness iOrderdetailsBusiness;

        public OrderdetailsController(IOrderdetailsBusiness iOrderdetailsBusiness)
        {
            this.iOrderdetailsBusiness = iOrderdetailsBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iOrderdetailsBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new OrderdetailsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(OrderdetailsViewModel model)
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
        public IActionResult Detail(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(OrderdetailsViewModel model)
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

        public IActionResult Delete(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Delete(orderNumber, productCode);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { orderNumber, productCode });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iOrderdetailsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}