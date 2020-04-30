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
            double total = invoicegenerator.TotalFare("normal",15, 20);
            Assert.AreEqual(170, total);
        }

        /// <summary>
        /// UC-2: Test case to calculate aggregate fare for multiple Rides
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnCalculateAggregateTotal()
        {
            Ride[] ride = {
                new Ride("normal",50,20),
                new Ride("normal",10,30)
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
                new Ride("normal",10,12),
                new Ride("normal",10,14),
                new Ride("normal",20,18)
            };
            double totalfare = invoice.CalculateMonthlyFare(ride);
            int totalRides = invoice.numberOfRides;
            double averageFare = Math.Round(invoice.Aggregate, 2);
            Assert.AreEqual(444, totalfare);
            Assert.AreEqual(3, totalRides);
            Assert.AreEqual(148.0, averageFare);
        }

        /// <summary>
        /// UC-4: Test case to calculate total fare of userID.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "rajesh.sharma@gmail.com";
            Ride[] ride = {
                new Ride("normal",20,15),
                new Ride("normal",10,25),
                new Ride("normal",12,40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            Invoicegenerator invoice = new Invoicegenerator();
            double totalFare = invoice.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(500, totalFare);
        }

        /// <summary>
        /// UC-5: Test case for 2 categories of rides
        /// </summary>
        [Test]
        public void GivenUserId_whenNormalandPremiumJoourney_ReturnTotalFare()
        {
            string userId = "rajesh.sharma@gmail.com";
            Ride[] ride = {
                new Ride("premium",50,15),
                new Ride("normal",30,25),
                new Ride("premium",60,40),
                new Ride("normal",12,40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            Invoicegenerator invoice = new Invoicegenerator();
            double totalFare = invoice.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(2245, totalFare);
        }
    }
}