using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerTravelPackageId { get; set; }
        public CustomerTravelPackage CustomerTravelPackage { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
