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
    public class CustomersController : ControllerBase
    {
        private ICustomersBusiness iCustomersBusiness;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger,
                    ICustomersBusiness iCustomersBusiness)
        {
            this._logger = logger;
            this.iCustomersBusiness = iCustomersBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<CustomersViewModel> Create(CustomersViewModel model)
        {
            var response = iCustomersBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<CustomersViewModel> Detail(int customerNumber)
        {
            var response = iCustomersBusiness.Read(customerNumber);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(CustomersViewModel model)
        {
            var response = iCustomersBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int customerNumber)
        {
            var result = iCustomersBusiness.Delete(customerNumber);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<CustomersViewModel>> ReadAll()
        {
            var response = iCustomersBusiness.ReadAll();
            return response;
        }
    }
}