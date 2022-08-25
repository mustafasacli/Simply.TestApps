using Mst.Project.ViewModel;
using Mst.Project.Business.Interfaces;
using Mst.Project.Dtos;
using SimpleInfra.Common.Response;
using SimpleInfra.Common.Core;
using Gsb.IoC;
using SimpleInfra.Validation;
using SimpleInfra.Mapping;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Mst.Project.Web.Controllers
{
    public class OfficesController : ApiController
    {
        private IOfficesBusiness iOfficesBusiness;

        public OfficesController(IOfficesBusiness iOfficesBusiness = null)
        {
            this.iOfficesBusiness = iOfficesBusiness ?? 
                GsbIoC.Instance.GetInstance<IOfficesBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(OfficesViewModel model)
        {
            var response = new SimpleResponse<OfficesViewModel>();
            response = iOfficesBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(string officeCode)
        {
            var modelResult = iOfficesBusiness.Read(officeCode);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(OfficesViewModel model)
        {
            var response = new SimpleResponse();
            response = iOfficesBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(string officeCode)
        {
            var result = iOfficesBusiness.Delete(officeCode);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iOfficesBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}