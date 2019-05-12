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
        public IActionResult GetCities()
        {
            var result = CitiesDataStore.Current.Cities;
            return Ok(result);  
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var result = CitiesDataStore.Current.Cities.Find(c=>c.Id == id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}