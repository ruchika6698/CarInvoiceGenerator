using CarService;
using NUnit.Framework;

namespace TestCarService
{
    public class Tests
    {
        Invoicegenerator invoicegenerator = new Invoicegenerator();
        /// <summary>
        /// UC-1: Test case to calculate fare for journey
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenInvoiceGeneratorMust_ReturntotalFareForJourney()
        {
            double total = invoicegenerator.TotalFare(15, 20);
            Assert.AreEqual(170, total);
        }

        /// <summary>
        /// UC-2: Test case to calculate aggregate fare for multiple Rides
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_AndCalculateAggregateTotal()
        {
            Ride[] ride = {
                new Ride(50,20),
                new Ride(10,30)
            };
            double total = invoicegenerator.TotalFare(ride);
            Assert.AreEqual(325, total);
        }
    }
}