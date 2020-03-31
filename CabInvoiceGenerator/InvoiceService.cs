using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService
    {
       public int costPerKilometer = 10;
        public int costPerMinute = 1;
        public int minimumFare = 5;

        public double TotalFare(double distance , double time)
        {
            double totalFare = distance * this.costPerKilometer + time * this.costPerMinute;
            if(totalFare > minimumFare)
            {
                return totalFare;
            }

            return minimumFare;
        }
    }
}
