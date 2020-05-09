using MongoDBCRUDWebAPICore.Models;
using MongoDBCRUDWebAPICore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MongoDBCRUDWebAPICore.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<City>> Get() =>
            _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpPost]
        public ActionResult<City> Create(City city)
        {
            _cityService.Create(city);

            return CreatedAtRoute("GetCity", new { id = city.Id.ToString() }, city);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, City bookIn)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            _cityService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var city = _cityService.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            _cityService.Remove(city.Id);

            return NoContent();
        }
    }
}