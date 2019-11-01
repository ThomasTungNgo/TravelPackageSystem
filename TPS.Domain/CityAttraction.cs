using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class CityAttraction
    {
        public CityAttraction()
        {
            TravelPackageCityAttractions = new List<TravelPackageCityAttraction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
        public List<TravelPackageCityAttraction> TravelPackageCityAttractions { get; set; }

    }
}
