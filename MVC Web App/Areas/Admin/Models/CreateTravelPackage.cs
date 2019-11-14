using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPS.Domain;

namespace MVC_Web_App.Areas.Admin.Models
{
    public class CreateTravelPackage
    {
        public int Id { get; set; }
        public TPS.Domain.City City { get; set; }
        public Attraction Attraction { get; set; }
        public int NumberOfDays { get; set; }
        public double RRP { get; set; }
    }
}
