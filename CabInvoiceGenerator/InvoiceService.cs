using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService
    {
        
        private readonly int costPerKilometreNormal = 10;
        private readonly int minimumFareNormal = 5;
        private readonly int costPerMinuteNormal = 1;
        private readonly int costPerKilometrePremium = 15;
        private readonly int minimumFarePremium = 20;
        private readonly int costPerMinutePremium = 2;
        private double totalCost = 0;
        private double totalFare = 0;
        private double averageFare = 0;
        private int numberOfRides = 0;

      
        public double Aggregate
        {
            get
            {
                return this.averageFare;
            }
        }

        public int TotalRides
        {
            get
            {
                return this.numberOfRides;
            }
        }

        public double TotalFare(string journeyType, double distance, double time)
        {
            if (journeyType == "normal")
            {
                this.totalCost = (distance * this.costPerKilometreNormal) + (time * this.costPerMinuteNormal);
                if (this.totalCost > this.minimumFareNormal)
                {
                    return this.totalCost;
                }

                return this.minimumFareNormal;
            }

            this.totalCost = (distance * this.costPerKilometrePremium) + (time * this.costPerMinutePremium);
            if (this.totalCost > this.minimumFarePremium)
            {
                return this.totalCost;
            }

            return this.minimumFarePremium;
        }

        public double CalculateMonthlyFare(Ride[] ride)
        {
            foreach (var item in ride)
            {
                this.totalFare = this.totalFare + this.TotalFare(item.RideType, item.Distance, item.Time);
            }

            this.numberOfRides = ride.Length;
            this.averageFare = this.totalFare / this.numberOfRides;
            return this.totalFare;
        }
    }
}
