using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            var result = CitiesDataStore.Current.Cities;
            return new JsonResult(result);       
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            var result = CitiesDataStore.Current.Cities.Find(c=>c.Id == id);
            return new JsonResult(result);
        }
    }
}