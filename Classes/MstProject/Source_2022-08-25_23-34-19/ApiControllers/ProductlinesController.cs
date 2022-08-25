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
    public class ProductlinesController : ApiController
    {
        private IProductlinesBusiness iProductlinesBusiness;

        public ProductlinesController(IProductlinesBusiness iProductlinesBusiness = null)
        {
            this.iProductlinesBusiness = iProductlinesBusiness ?? 
                GsbIoC.Instance.GetInstance<IProductlinesBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ProductlinesViewModel model)
        {
            var response = new SimpleResponse<ProductlinesViewModel>();
            response = iProductlinesBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(string productLine)
        {
            var modelResult = iProductlinesBusiness.Read(productLine);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ProductlinesViewModel model)
        {
            var response = new SimpleResponse();
            response = iProductlinesBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(string productLine)
        {
            var result = iProductlinesBusiness.Delete(productLine);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iProductlinesBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}