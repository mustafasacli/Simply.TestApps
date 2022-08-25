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
    public class ProductlinesController : OzelYurtBaseController
    {
        private IProductlinesBusiness iProductlinesBusiness;

        public ProductlinesController(IProductlinesBusiness iProductlinesBusiness = null)
        {
            this.iProductlinesBusiness = iProductlinesBusiness ??
                GsbIoC.Instance.GetInstance<IProductlinesBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iProductlinesBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new ProductlinesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(ProductlinesViewModel model)
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
        public ActionResult Detail(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(ProductlinesViewModel model)
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

        public ActionResult Delete(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(string productLine)
        {
            var response = iProductlinesBusiness.Delete(productLine);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { productLine });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iProductlinesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}