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
    public class EmployeesController : ControllerBase
    {
        private IEmployeesBusiness iEmployeesBusiness;

        public EmployeesController(IEmployeesBusiness iEmployeesBusiness)
        {
            this.iEmployeesBusiness = iEmployeesBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iEmployeesBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new EmployeesViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(EmployeesViewModel model)
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
        public IActionResult Detail(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(EmployeesViewModel model)
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

        public IActionResult Delete(int employeeNumber)
        {
            var response = iEmployeesBusiness.Read(employeeNumber);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int employeeNumber)
        {
            var response = iEmployeesBusiness.Delete(employeeNumber);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { employeeNumber });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iEmployeesBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}