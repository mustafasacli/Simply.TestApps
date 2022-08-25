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
    public class OfficesController : OzelYurtBaseController
    {
        private IOfficesBusiness iOfficesBusiness;

        public OfficesController(IOfficesBusiness iOfficesBusiness = null)
        {
            this.iOfficesBusiness = iOfficesBusiness ??
                GsbIoC.Instance.GetInstance<IOfficesBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iOfficesBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new OfficesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(OfficesViewModel model)
        {
            var response = iOfficesBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(OfficesViewModel model)
        {
            var response = iOfficesBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(string officeCode)
        {
            var response = iOfficesBusiness.Delete(officeCode);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { officeCode });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iOfficesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}