using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TPS.Domain;
using TPS.Service;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CityService _service;

        public ValuesController(CityService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _service.GetTopOneHundred();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values/"name"
        [HttpGet("{name}")]
        public IEnumerable<City> GetCityAttractions(string value)
        {
            return _service.GetCityAttractions(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
