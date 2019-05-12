using System.Collections.Generic;

namespace CityInfo.API.Controllers
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
                    Description = "Motor City"
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Flint",
                    Description = "Parents Home"
                },
                new CityDto
                {
                    Id = 1,
                    Name = "Lapeer",
                    Description = "Danks House"
                },
            };
        }
    }

}