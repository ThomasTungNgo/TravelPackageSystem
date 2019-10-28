using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public enum TravelPackageStatus { Draft = 1, Active = 2, Cancelled = 3 }
    public class TravelPackage
    {
        public TravelPackage()
        {
            Cities = new List<TravelPackageCity>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; private set; }
        public TravelPackageStatus Status { get => (TravelPackageStatus)StatusId; } 
        //recommended retail price
        public decimal RRP { get; set; }

        public TravelPackageCity AddCity(City c,int days, params CityAttraction[] attractions)
        {
            var tpc = new TravelPackageCity
            {
                 City = c,
                 NumberOfDays = days,
                 TravelPackage = this
            };
            Cities.Add(tpc);

            if(attractions != null)
            {
                foreach(var a in attractions)
                {
                    tpc.AddAttraction(a);
                }
            }
            return tpc;
        }
       
        public List<TravelPackageCity> Cities { get; set; }

    }
}
