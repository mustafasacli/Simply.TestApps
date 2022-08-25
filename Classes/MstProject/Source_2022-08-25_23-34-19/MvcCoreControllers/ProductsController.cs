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
    public class ProductsController : ControllerBase
    {
        private IProductsBusiness iProductsBusiness;

        public ProductsController(IProductsBusiness iProductsBusiness)
        {
            this.iProductsBusiness = iProductsBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iProductsBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new ProductsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(ProductsViewModel model)
        {
            var response = iProductsBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ProductsViewModel model)
        {
            var response = iProductsBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string productCode)
        {
            var response = iProductsBusiness.Delete(productCode);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { productCode });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iProductsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}