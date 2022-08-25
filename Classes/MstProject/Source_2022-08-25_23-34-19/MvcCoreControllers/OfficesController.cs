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
    public class OfficesController : ControllerBase
    {
        private IOfficesBusiness iOfficesBusiness;

        public OfficesController(IOfficesBusiness iOfficesBusiness)
        {
            this.iOfficesBusiness = iOfficesBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iOfficesBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new OfficesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(OfficesViewModel model)
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
        public IActionResult Detail(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(OfficesViewModel model)
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

        public IActionResult Delete(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string officeCode)
        {
            var response = iOfficesBusiness.Delete(officeCode);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { officeCode });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iOfficesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}