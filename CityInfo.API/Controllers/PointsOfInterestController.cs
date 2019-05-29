using System;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfo.API.Controllers
{
    [Route("/api/cities")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                _logger.LogInformation($"City with id {cityId} was not found");
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c=>c.Id == id);
            if(pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointsofinterest)
        {
            if(pointsofinterest == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            return CreatedAtRoute("GetPointOfInterest", new {cityId = cityId, id = finalPointOfInterest.Id },finalPointOfInterest);

        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if(pointOfInterest == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = city.PointsOfInterest.FirstOrDefault(c=>c.Id == id);
            if(pointOfInterestFound == null)
            {
                return NotFound();
            }

            pointOfInterestFound.Name = pointOfInterest.Name;
            pointOfInterestFound.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

              var city = CitiesDataStore.Current.Cities.Find(x=> x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var pointOfInterestFound = city.PointsOfInterest.FirstOrDefault(c=>c.Id == id);
            if(pointOfInterestFound == null)
            {
                return NotFound();
            }

            var pointOfInterestForPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFound.Name,
                Description = pointOfInterestFound.Description
            };

            patchDoc.ApplyTo(pointOfInterestForPatch, ModelState);

            TryValidateModel(pointOfInterestForPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFound.Name = pointOfInterestForPatch.Name;
            pointOfInterestFound.Description = pointOfInterestForPatch.Description;

            return NoContent();
        }

        //TODO add httpdelete action as an example

    }
}