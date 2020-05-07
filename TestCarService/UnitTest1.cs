///-----------------------------------------------------------------
///   Class:       Tests
///   Description: Test Cases for cab service subcription
///   Author:      Ruchika                   Date: 30/4/2020
///-----------------------------------------------------------------

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
            try
            {
                double totalfare = invoicegenerator.TotalFare("normal", 15, 20);
                Assert.AreEqual(170, totalfare);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC-2: Test case to calculate aggregate fare for multiple Rides
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnCalculateAggregateTotal()
        {
            try
            {
                //add number of rides
                Ride[] ride = {
                new Ride("normal",50,20),
                new Ride("normal",10,30)
                };
                //calculate total fare
                double totalfare = invoicegenerator.CalculateMonthlyFare(ride);
                Assert.AreEqual(650, totalfare);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC-3: Test case to calculate total fare,no. of rides,average
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnEnhancedInVoice()
        {
            try
            {
                Invoicegenerator carride = new Invoicegenerator();
                //add number of rides
                Ride[] ride = {
                new Ride("normal",10,12),
                new Ride("normal",10,14),
                new Ride("normal",20,18)
                };
                //calculate total fare
                double totalfare = carride.CalculateMonthlyFare(ride);
                //calculate number of rides
                int totalRides = carride.numberofRides;
                //calculate average fare for rides
                double averageFare = Math.Round(carride.Aggregate, 2);
                Assert.AreEqual(444, totalfare);
                Assert.AreEqual(3, totalRides);
                Assert.AreEqual(148.0, averageFare);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC-4: Test case to calculate total fare of userID.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            try
            {
                //add user rides using user ID
                string userId = "rajesh.sharma@gmail.com";
                //add number of rides
                Ride[] ride = {
                new Ride("normal",20,15),
                new Ride("normal",10,25),
                new Ride("normal",12,40)
                };
                RideRepository rideRepository = new RideRepository();
                //add userID and rides
                rideRepository.AddRides(userId, ride);
                Invoicegenerator carride = new Invoicegenerator();
                //calculate total cab fare for all rides
                double ridetotalFare = carride.CalculateMonthlyFare(rideRepository.GetRides(userId));
                Assert.AreEqual(500, ridetotalFare);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC-5: Test case for 2 categories of rides
        /// </summary>
        [Test]
        public void GivenUserId_whenNormalandPremiumJoourney_ReturnTotalFare()
        {
            try
            {
                //add user rides using user ID
                string userId = "rajesh.sharma@gmail.com";
                //add number of rides
                Ride[] ride = {
                new Ride("premium",50,15),
                new Ride("normal",30,25),
                new Ride("premium",60,40),
                new Ride("normal",12,40)
                };
                RideRepository rideRepository = new RideRepository();
                //add userID and rides
                rideRepository.AddRides(userId, ride);
                Invoicegenerator carride = new Invoicegenerator();
                //calculate total cab fare for all rides
                double ridetotalFare = carride.CalculateMonthlyFare(rideRepository.GetRides(userId));
                Assert.AreEqual(2245, ridetotalFare);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}