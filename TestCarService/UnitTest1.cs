using CarService;
using NUnit.Framework;
using System;

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
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnCalculateAggregateTotal()
        {
            Ride[] ride = {
                new Ride(50,20),
                new Ride(10,30)
            };
            double total = invoicegenerator.CalculateMonthlyFare(ride);
            Assert.AreEqual(650, total);
        }

        /// <summary>
        /// UC-3: Test case to calculate total fare,no. of rides,average
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnEnhancedInVoice()
        {
            Invoicegenerator invoice = new Invoicegenerator();
            Ride[] ride = {
                new Ride(10,12),
                new Ride(10,14),
                new Ride(20,18)
            };
            double totalfare = invoice.CalculateMonthlyFare(ride);
            int totalRides = invoice.totalRides;
            double averageFare = Math.Round(invoice.Aggregate, 2);
            Assert.AreEqual(444, totalfare);
            Assert.AreEqual(3, totalRides);
            Assert.AreEqual(148.0, averageFare);
        }

        /// <summary>
        /// UC-4: Test case to calculate total fare of userID.
        /// </summary>
        [Test]
        public void NormalAndPremiumRides()
        {
            string userId = "rajesh.aharma@gmail.com";
            Ride[] ride = {
                new Ride(20,15),
                new Ride(10,25),
                new Ride(12,40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            Invoicegenerator invoice = new Invoicegenerator();
            double totalFare = invoice.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(500, totalFare);
        }
    }
}