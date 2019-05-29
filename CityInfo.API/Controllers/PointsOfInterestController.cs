using System;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("/api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest", Name = "GetPointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpPost("{cityId/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestFoCreationDto pointsofinterest)
        {
            if(pointsofinterest == null)
            {
                return BadRequest();
            }
 
            var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            //TODO remove this
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                c=> c.PointsOfInterest).Max(p=>p.Id);
            
            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointsofinterest.Name,
                Description = pointsofinterest.Description

            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute()

        }

    }
}