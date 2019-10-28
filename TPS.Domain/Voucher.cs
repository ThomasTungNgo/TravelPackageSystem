using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class Voucher
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime Expires { get; set; }
        public bool Valid { get; set; }
    }
}
