using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPS.Domain;

namespace TPS.Service
{
    public class CityService
    {
        private readonly TPSDbContext _context;

        public CityService(TPSDbContext context)
        {
            _context = context;
        }

        //Add a City Attraction
        public CityAttraction AddAttraction (string name, string description, int cityId)
        {
            var ca = new CityAttraction
            {
                Name = name,
                Description = description,
                CityId = cityId
            };

            _context.Add(ca);
            _context.SaveChanges();
            return ca;
        }

        public string GetTopOneHundred()
        {
            return _context.Cities.Take(100).ToString();
        }
    }
}
