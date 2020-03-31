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
        public double totalFare = 0;
        public int totalRides = 0;
        public double aggregateFare = 0;

        public double Aggregate
        {
            get
            {
                return this.aggregateFare;
            }
        }

        public int Rides
        {
            get
            {
                return this.totalRides;
            }
        }

        public double TotalFare(double distance , double time)
        {
            double totalFare = distance * this.costPerKilometer + time * this.costPerMinute;
            if(totalFare > minimumFare)
            {
                return totalFare;
            }

            return minimumFare;
        }

        public double TotalFare(Ride[] rides)
        {
           foreach (var total in rides)
           {
                 totalFare = totalFare + TotalFare(total.distance, total.time);
           }

            totalRides = rides.Length;
            aggregateFare = totalFare/totalRides;
            return totalFare;
        }
    }
}
