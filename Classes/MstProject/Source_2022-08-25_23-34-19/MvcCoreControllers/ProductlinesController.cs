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
    public class ProductlinesController : ControllerBase
    {
        private IProductlinesBusiness iProductlinesBusiness;

        public ProductlinesController(IProductlinesBusiness iProductlinesBusiness)
        {
            this.iProductlinesBusiness = iProductlinesBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iProductlinesBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new ProductlinesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(ProductlinesViewModel model)
        {
            var response = iProductlinesBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ProductlinesViewModel model)
        {
            var response = iProductlinesBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string productLine)
        {
            var response = iProductlinesBusiness.Delete(productLine);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { productLine });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iProductlinesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}