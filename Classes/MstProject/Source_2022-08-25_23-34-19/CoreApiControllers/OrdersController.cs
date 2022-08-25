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
    public class OrdersController : ControllerBase
    {
        private IOrdersBusiness iOrdersBusiness;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger,
                    IOrdersBusiness iOrdersBusiness)
        {
            this._logger = logger;
            this.iOrdersBusiness = iOrdersBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<OrdersViewModel> Create(OrdersViewModel model)
        {
            var response = iOrdersBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<OrdersViewModel> Detail(int orderNumber)
        {
            var response = iOrdersBusiness.Read(orderNumber);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(OrdersViewModel model)
        {
            var response = iOrdersBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int orderNumber)
        {
            var result = iOrdersBusiness.Delete(orderNumber);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<OrdersViewModel>> ReadAll()
        {
            var response = iOrdersBusiness.ReadAll();
            return response;
        }
    }
}