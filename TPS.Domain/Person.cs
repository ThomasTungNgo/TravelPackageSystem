using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public int TravelProviderId { get; set; }
        public TravelProvider TravelProvider { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
