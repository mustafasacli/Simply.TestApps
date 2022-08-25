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
    public class PaymentsController : ControllerBase
    {
        private IPaymentsBusiness iPaymentsBusiness;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger,
                    IPaymentsBusiness iPaymentsBusiness)
        {
            this._logger = logger;
            this.iPaymentsBusiness = iPaymentsBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<PaymentsViewModel> Create(PaymentsViewModel model)
        {
            var response = iPaymentsBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<PaymentsViewModel> Detail(int customerNumber, string checkNumber)
        {
            var response = iPaymentsBusiness.Read(customerNumber, checkNumber);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(PaymentsViewModel model)
        {
            var response = iPaymentsBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int customerNumber, string checkNumber)
        {
            var result = iPaymentsBusiness.Delete(customerNumber, checkNumber);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<PaymentsViewModel>> ReadAll()
        {
            var response = iPaymentsBusiness.ReadAll();
            return response;
        }
    }
}