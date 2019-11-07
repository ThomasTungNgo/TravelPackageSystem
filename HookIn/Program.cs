using System;
using System.Linq;
using TPS.Domain;
using TPS.Service;

namespace HookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Using Domain DbContext
            var dbDomain = new TPSDbContext();
            var listCities = dbDomain.Cities.Where(c => c.Name == "Sydney").ToList();

            //Using Service DbContext
            //var cityAttractionService = new CityService();

            //cityAttractionService
            //    .AddAttraction("Harbour Bridge", "A Simple Bridge", 1036074917);


        }
    }
}

