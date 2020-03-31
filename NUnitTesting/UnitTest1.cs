using CabInvoiceGenerator;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_InvoiceGeneratorMustReturn_TotalFareForJourney()
        {
            InvoiceService invoice = new InvoiceService();
            double total = invoice.TotalFare(10,12);
            Assert.AreEqual(112, total);
        }

        [Test]
        public void InvoiceGeneratorMustTakeMultipleRides_AndCalculateAggregateTotal()
        {
            InvoiceService invoice = new InvoiceService();
            Ride [] ride = { 
                new Ride(10,12),
                new Ride(15, 10)
            };
            double total = invoice.TotalFare(ride);
            Assert.AreEqual(272, total);
        }
    }
}