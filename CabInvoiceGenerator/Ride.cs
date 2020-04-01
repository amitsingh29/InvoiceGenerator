using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distance;
        public double time;
        public string rideType;
        public Ride(string rideType,double distance, double time)
        {
            this.rideType = rideType;
            this.distance = distance;
            this.time = time;
        }

        public double Distance
        {
            get
                {
                return this.distance;
                }
        }

        public string RideType
        {
            get
            {
                return this.rideType;
            }
        }

        public double Time
        {
            get
            {
                return this.time;
            }
        }
    }
}
