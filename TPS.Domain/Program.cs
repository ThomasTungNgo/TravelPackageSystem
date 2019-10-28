using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TPS.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TPSDbContext();
            

            var package = new TravelPackage
            {
                 Name = "Australia East Coast",
                 Description = "10 days in Brisbase & Sydney",
                 RRP = 1500
            };
            db.TravelPackages.Add(package);
            var sydney = db.Cities
                .Include(c=>c.Attractions)
                .First(c => c.Id == 1036074917);

            var harbourBridge = sydney.Attractions.Where(a => a.Id == 1).First();
            var blueMountains = sydney.Attractions.Where(a => a.Id == 4).First();

            package.AddCity(sydney, 5,harbourBridge, blueMountains);

            var brisbane = db.Cities
                 .Include(c => c.Attractions)
                .First(c => c.Id == 1036192929);

            var allOfBrisbaneAttractions = brisbane.Attractions.ToArray(); 

            package.AddCity(brisbane, 5, allOfBrisbaneAttractions);

            db.SaveChanges(); 
        }
    }
}
