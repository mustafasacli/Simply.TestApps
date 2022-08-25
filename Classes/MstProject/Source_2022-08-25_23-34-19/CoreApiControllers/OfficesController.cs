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
    public class OfficesController : ControllerBase
    {
        private IOfficesBusiness iOfficesBusiness;
        private readonly ILogger<OfficesController> _logger;

        public OfficesController(ILogger<OfficesController> logger,
                    IOfficesBusiness iOfficesBusiness)
        {
            this._logger = logger;
            this.iOfficesBusiness = iOfficesBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<OfficesViewModel> Create(OfficesViewModel model)
        {
            var response = iOfficesBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<OfficesViewModel> Detail(string officeCode)
        {
            var response = iOfficesBusiness.Read(officeCode);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(OfficesViewModel model)
        {
            var response = iOfficesBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(string officeCode)
        {
            var result = iOfficesBusiness.Delete(officeCode);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<OfficesViewModel>> ReadAll()
        {
            var response = iOfficesBusiness.ReadAll();
            return response;
        }
    }
}