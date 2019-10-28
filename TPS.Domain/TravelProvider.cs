using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPS.Domain
{
    public class TravelProvider
    {
        public TravelProvider()
        {
            People = new List<Person>(); 
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> People { get; set; }


        public List<Employee> Employees { get => People.OfType<Employee>().ToList();  }
        public List<Customer> Customers { get => People.OfType<Customer>().ToList(); }
    }
}
