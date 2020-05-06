///-----------------------------------------------------------------
///   Class:       Invoicegenerator
///   Description: Calculate TotalFare for diffent journey type
///   Author:      Ruchika                   Date: 30/4/2020
///-----------------------------------------------------------------

using System;

namespace CarService
{
    public class Invoicegenerator
    {
        /// <summary>
        /// constants values for costperkm,costpermin,minimumfare
        /// </summary>
        public int Costperkilometernormal = 10;
        public int Costperminutenormal = 1;
        public int Minimumfarenormal = 5;
        public int Costperkilometerpremium = 15;
        public int Costperminutepremium = 2;
        public int Minimumfarepremium = 20;
        public double totalFare = 0;
        public int numberOfRides = 0;
        public double averageFare = 0;
       
        /// <summary>
        /// return aggregate value
        /// </summary>
        public double Aggregate
        {
            get
            {
                return this.averageFare;
            }
        }

        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to subscription based car service");
        }

        /// <summary>
        /// Method to calculate total fare of car
        /// </summary>
        /// <param name="journeytype"> Type of Journey </param>
        /// <param name="distance"> Distance </param>
        /// <param name="time"> Time </param>
        /// <returns> Total Fare </returns>
        public double TotalFare(string journeytype,double distance, double time)
        {
            if (journeytype == "normal")
            {
                //if the totalfare is greater than minimum fare then return totalfare
                if (((distance * Costperkilometernormal) + (time * Costperminutenormal)) > Minimumfarenormal)
                {
                    return (distance * Costperkilometernormal) + (time * Costperminutenormal);
                }
                return Minimumfarenormal;
            }
            //if the totalcost is greater than minimum fare then return totalfare minimumFarePremium
            if (((distance * Costperkilometerpremium) + (time * Costperminutepremium)) > Minimumfarepremium)
            {
                return (distance * Costperkilometerpremium) + (time * Costperminutepremium);
            }
            return Minimumfarepremium;
        }

        /// <summary>
        /// Method to calculate total fare of car with multiple rides
        /// </summary>
        /// <param name="rides"> Array to store rides </param>
        /// <returns> Calculate Monthly Fare </returns>
        public double CalculateMonthlyFare(Ride[] rides)
        {
            //calculate Total Fare for multipme rides
            foreach (var total in rides)
            {
                totalFare += TotalFare(total.rideType, total.distance, total.time);
            }
            //calculate number of rides
            numberOfRides = rides.Length;
            //calculate aggregate of monthly fare
            averageFare = totalFare / numberOfRides;
            return totalFare;
        }
    }
}