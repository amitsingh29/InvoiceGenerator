using CabInvoiceGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTesting
{
    public class Tests
    {
        private object invoiceService;

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

        [Test]
        public void InvoiceGeneratorMustReturn_TotalNumberOfRides_TotalFare_AverageFarePerRide()
        {
            InvoiceService invoice = new InvoiceService();
            Ride[] ride = {
                new Ride(10,12),
                new Ride(10, 14),
                new Ride(20,18)
            };
            double total = invoice.TotalFare(ride);
            int totalRides = invoice.totalRides;
            double averageFare = Math.Round(invoice.Aggregate, 2);
            Assert.AreEqual(444, total);
            Assert.AreEqual(3, totalRides);
            Assert.AreEqual(148.0, averageFare);
        }

        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "amitSingh@gmail.com";
            Ride[] ride = {
                new Ride(5,15),
                new Ride(10,25),
                new Ride(15,40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoice = new InvoiceService();
            double totalFare = invoice.TotalFare(rideRepository.GetRides(userId));
            Assert.AreEqual(380, totalFare);
        }
    }
}