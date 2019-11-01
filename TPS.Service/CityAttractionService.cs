using System;
using System.Collections.Generic;
using System.Text;
using TPS.Domain;

namespace TPS.Service
{
    public class CityAttractionService : TPS.Domain.CityAttraction
    {
        private readonly TPSDbServiceContext _context;

        //public CityAttractionService (TPSDbServiceContext context)
        //{
        //    _context = context;
        //}

        //Add a City Attraction
        public void AddAttraction (string name, string description, int CityId)
        {
            var newCityAttraction = new CityAttraction()
            {
                Name = name,
                Description = description,
                Id = CityId
            };

            _context.Add(newCityAttraction);
            _context.SaveChanges();
        }
    }
}
