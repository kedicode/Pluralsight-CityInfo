using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new { Id = 1 , Name = "Detroit"},
                new { Id = 2 , Name = "Flint"}

            });
        }

        [Route("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(new List<City>()
            {
                new City { Id = 1 , Name = "Detroit"},
                new City { Id = 2 , Name = "Flint"}

            }.Where(x=>x.Id == id));
        }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}