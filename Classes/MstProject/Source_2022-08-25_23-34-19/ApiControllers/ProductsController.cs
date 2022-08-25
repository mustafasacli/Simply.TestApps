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
    public class ProductsController : ApiController
    {
        private IProductsBusiness iProductsBusiness;

        public ProductsController(IProductsBusiness iProductsBusiness = null)
        {
            this.iProductsBusiness = iProductsBusiness ?? 
                GsbIoC.Instance.GetInstance<IProductsBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ProductsViewModel model)
        {
            var response = new SimpleResponse<ProductsViewModel>();
            response = iProductsBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(string productCode)
        {
            var modelResult = iProductsBusiness.Read(productCode);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ProductsViewModel model)
        {
            var response = new SimpleResponse();
            response = iProductsBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(string productCode)
        {
            var result = iProductsBusiness.Delete(productCode);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iProductsBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}