using CarService;
using NUnit.Framework;

namespace TestCarService
{
    public class Tests
    {
        CabInvoiceGenerator invoicegenerator = new CabInvoiceGenerator();
        /// <summary>
        /// UC-1: Test case to calculate fare for journey
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenInvoiceGeneratorMust_ReturntotalFareForJourney()
        {
            double total = invoicegenerator.TotalFare(15, 20);
            Assert.AreEqual(170, total);
        }
    }
}