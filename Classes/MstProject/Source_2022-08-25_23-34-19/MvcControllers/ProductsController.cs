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
    public class ProductsController : OzelYurtBaseController
    {
        private IProductsBusiness iProductsBusiness;

        public ProductsController(IProductsBusiness iProductsBusiness = null)
        {
            this.iProductsBusiness = iProductsBusiness ??
                GsbIoC.Instance.GetInstance<IProductsBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iProductsBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new ProductsViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(ProductsViewModel model)
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
        public ActionResult Detail(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(ProductsViewModel model)
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

        public ActionResult Delete(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(string productCode)
        {
            var response = iProductsBusiness.Delete(productCode);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { productCode });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iProductsBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}