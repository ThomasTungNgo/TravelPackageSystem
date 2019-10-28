using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class BitcoinPayment : Payment
    {
        public string TransactionHashcode { get; set; }
    }
}
