using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPS.Domain;
using TPS.Service;

namespace TPS.Web_MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CityService service;

        public ValuesController(CityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<City> GetTopOneHundred()
        {
            return service.GetTopOneHundred();
        }
    }
}