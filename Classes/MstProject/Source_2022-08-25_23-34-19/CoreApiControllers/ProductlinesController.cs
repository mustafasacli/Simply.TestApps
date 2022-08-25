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
    public class ProductlinesController : ControllerBase
    {
        private IProductlinesBusiness iProductlinesBusiness;
        private readonly ILogger<ProductlinesController> _logger;

        public ProductlinesController(ILogger<ProductlinesController> logger,
                    IProductlinesBusiness iProductlinesBusiness)
        {
            this._logger = logger;
            this.iProductlinesBusiness = iProductlinesBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<ProductlinesViewModel> Create(ProductlinesViewModel model)
        {
            var response = iProductlinesBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<ProductlinesViewModel> Detail(string productLine)
        {
            var response = iProductlinesBusiness.Read(productLine);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(ProductlinesViewModel model)
        {
            var response = iProductlinesBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(string productLine)
        {
            var result = iProductlinesBusiness.Delete(productLine);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<ProductlinesViewModel>> ReadAll()
        {
            var response = iProductlinesBusiness.ReadAll();
            return response;
        }
    }
}