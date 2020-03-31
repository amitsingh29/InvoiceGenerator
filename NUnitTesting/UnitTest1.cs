using CabInvoiceGenerator;
using NUnit.Framework;

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
    }
}