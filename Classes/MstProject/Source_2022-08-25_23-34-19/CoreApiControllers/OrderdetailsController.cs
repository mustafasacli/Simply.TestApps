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
    public class OrderdetailsController : ControllerBase
    {
        private IOrderdetailsBusiness iOrderdetailsBusiness;
        private readonly ILogger<OrderdetailsController> _logger;

        public OrderdetailsController(ILogger<OrderdetailsController> logger,
                    IOrderdetailsBusiness iOrderdetailsBusiness)
        {
            this._logger = logger;
            this.iOrderdetailsBusiness = iOrderdetailsBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<OrderdetailsViewModel> Create(OrderdetailsViewModel model)
        {
            var response = iOrderdetailsBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<OrderdetailsViewModel> Detail(int orderNumber, string productCode)
        {
            var response = iOrderdetailsBusiness.Read(orderNumber, productCode);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(OrderdetailsViewModel model)
        {
            var response = iOrderdetailsBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int orderNumber, string productCode)
        {
            var result = iOrderdetailsBusiness.Delete(orderNumber, productCode);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<OrderdetailsViewModel>> ReadAll()
        {
            var response = iOrderdetailsBusiness.ReadAll();
            return response;
        }
    }
}