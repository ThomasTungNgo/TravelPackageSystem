using Microsoft.EntityFrameworkCore;
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
        public Attraction AddAttraction (string name, string description, int cityId)
        {
            var ca = new Attraction
            {
                Name = name,
                Description = description,
                CityId = cityId
            };

            _context.Add(ca);
            _context.SaveChanges();
            return ca;
        }

        public IEnumerable<City> GetTopOneHundred()
        {
            return _context.Cities.Take(100).ToList();
        }

        public IEnumerable<City> GetCityAttractions(string name)
        {
            return _context.Cities.Include("CityAttraction").Where(c => c.Name == name);
        } 
    }
}
