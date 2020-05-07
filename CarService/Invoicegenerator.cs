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
        public const int Costperkilometernormal = 10;
        public const int Costperminutenormal = 1;
        public const int Minimumfarenormal = 5;
        public const int Costperkilometerpremium = 15;
        public const int Costperminutepremium = 2;
        public const int Minimumfarepremium = 20;
        public double totalFare = 0;
        public int numberofRides = 0;
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
            try
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
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        /// <summary>
        /// Method to calculate total fare of car with multiple rides
        /// </summary>
        /// <param name="rides"> Array to store rides </param>
        /// <returns> Calculate Monthly Fare </returns>
        public double CalculateMonthlyFare(Ride[] rides)
        {
            try
            {
                //calculate Total Fare for multipme rides
                foreach (var total in rides)
                {
                    totalFare += TotalFare(total.rideType, total.distance, total.time);
                }
                //calculate number of rides
                numberofRides = rides.Length;
                //calculate aggregate of monthly fare
                averageFare = totalFare / numberofRides;
                return totalFare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}