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
        public Ride(double distance, double time)
        {
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

        public double Time
        {
            get
            {
                return this.time;
            }
        }
    }
}
