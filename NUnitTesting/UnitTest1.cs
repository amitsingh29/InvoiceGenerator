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
            double total = invoice.TotalFare("normal", 10, 12);
            Assert.AreEqual(112, total);
        }

        [Test]
        public void InvoiceGeneratorMustTakeMultipleRides_AndCalculateAggregateTotal()
        {
            InvoiceService invoice = new InvoiceService();
            Ride[] ride = {
                new Ride("normal", 10,12),
                new Ride("normal", 15, 10)
            };
            double total = invoice.CalculateMonthlyFare(ride);
            Assert.AreEqual(272, total);
        }

        [Test]
        public void InvoiceGeneratorMustReturn_TotalNumberOfRides_TotalFare_AverageFarePerRide()
        {
            InvoiceService invoice = new InvoiceService();
            Ride[] ride = {
                new Ride("normal", 10, 12),
                new Ride("normal", 10, 14),
                new Ride("normal", 20, 18)
            };
            double total = invoice.CalculateMonthlyFare(ride);
            int totalRides = invoice.TotalRides;
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
                new Ride("normal", 5, 15),
                new Ride("normal", 10, 25),
                new Ride("normal", 15, 40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoice = new InvoiceService();
            double totalFare = invoice.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(380, totalFare);
        }

        [Test]
        public void NormalAndPremiumRides()
        {
            string userId = "amitSingh@gmail.com";
            Ride[] ride =
            {
                new Ride("normal", 10, 20),
                new Ride("premium", 0.1, 1),
                new Ride("premium", 12, 25),
                new Ride("normal", 0.2, 2)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoiceService = new InvoiceService();
            double totalFare = invoiceService.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(375, totalFare);
        }
    }
}