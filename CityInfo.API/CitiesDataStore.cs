using System.Collections.Generic;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto
                {
                    Id = 1,
                    Name = "Detroit",
                    Description = "Motor City",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Campus Martius",
                            Description = "City Center Park with cool activities"
                        },

                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "1001 Woodward",
                            Description = "Home of Detroit We Work Space"
                        }
                    }
                    
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Flint",
                    Description = "Parents Home",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 3,
                            Name = "501 Club",
                            Description = "Tapas Bar in Downtown Awesome Place"
                        },
                    }
                },
                new CityDto
                {
                    Id = 3,
                    Name = "Lapeer",
                    Description = "Danks House",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 4,
                            Name = "Dank",
                            Description = "The Most Awesome Bulldog ever"
                        },
                    }
                },
            };
        }
    }

}