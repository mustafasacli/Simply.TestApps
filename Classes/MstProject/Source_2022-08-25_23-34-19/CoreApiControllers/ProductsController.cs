using Mst.Project.Business.Interfaces;
using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mst.Project.CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsBusiness iProductsBusiness;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger,
                    IProductsBusiness iProductsBusiness)
        {
            this._logger = logger;
            this.iProductsBusiness = iProductsBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<ProductsViewModel> Create(ProductsViewModel model)
        {
            var response = iProductsBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<ProductsViewModel> Detail(string productCode)
        {
            var response = iProductsBusiness.Read(productCode);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(ProductsViewModel model)
        {
            var response = iProductsBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(string productCode)
        {
            var result = iProductsBusiness.Delete(productCode);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<ProductsViewModel>> ReadAll()
        {
            var response = iProductsBusiness.ReadAll();
            return response;
        }
    }
}