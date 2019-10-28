using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class PayPalPayment : Payment
    {
        public string RecordOfCharge { get; set; }
    }
}
