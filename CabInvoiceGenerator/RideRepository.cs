using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRides(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userID, list);
            }
        }

        public Ride[] GetRides(string userID)
        {
            return this.userRides[userID].ToArray();
        }
    }
}
