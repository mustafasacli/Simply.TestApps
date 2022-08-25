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
    public class EmployeesController : OzelYurtBaseController
    {
        private IEmployeesBusiness iEmployeesBusiness;

        public EmployeesController(IEmployeesBusiness iEmployeesBusiness = null)
        {
            this.iEmployeesBusiness = iEmployeesBusiness ??
                GsbIoC.Instance.GetInstance<IEmployeesBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iEmployeesBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new EmployeesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(EmployeesViewModel model)
        {
            var response = iEmployeesBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(EmployeesViewModel model)
        {
            var response = iEmployeesBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int employeeNumber)
        {
            var response = iEmployeesBusiness.Delete(employeeNumber);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { employeeNumber });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iEmployeesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}