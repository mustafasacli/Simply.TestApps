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
    public class OrdersController : ControllerBase
    {
        private IOrdersBusiness iOrdersBusiness;

        public OrdersController(IOrdersBusiness iOrdersBusiness)
        {
            this.iOrdersBusiness = iOrdersBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iOrdersBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new OrdersViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(OrdersViewModel model)
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
        public IActionResult Detail(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(OrdersViewModel model)
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

        public IActionResult Delete(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int orderNumber)
        {
            var response = iOrdersBusiness.Delete(orderNumber);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { orderNumber });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iOrdersBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}