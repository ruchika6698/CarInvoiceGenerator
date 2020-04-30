using System;

namespace CarService
{
    public class Invoicegenerator
    {
        /// <summary>
        /// constants values for costperkm,costpermin,minimumfare
        /// </summary>
        public int costPerkilometerNormal = 10;
        public int costPerMinuteNormal = 1;
        public int minimumFareNormal = 5;
        public int costPerkilometerPremium = 15;
        public int costPerMinutePremium = 2;
        public int minimumFarePremium = 20;
        public double totalFare = 0;
        public double totalCost = 0;
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
        public double TotalFare(string journeytype,double distance, double time)
        {
            if (journeytype == "normal")
            {
                //calculate Total Fare for normal journey type
                //if the totalfare is greater than minimum fare then return totalfare
                if (((distance * costPerkilometerNormal) + (time * costPerMinuteNormal)) > minimumFareNormal)
                {
                    return (distance * costPerkilometerNormal) + (time * costPerMinuteNormal);
                }
                //if the totalfare is less than minimum fare then return totalfare
                return minimumFareNormal;
            }
            //calculate Total Fare for premium journey type
            double totalCost = (distance * costPerkilometerPremium) + (time * costPerMinutePremium);
            //if the totalcost is greater than minimum fare then return totalfare minimumFarePremium
            if (totalCost > minimumFarePremium)
            {
                return totalCost;
            }
            //if the totalfare is less than minimum fare then return totalfare
            return minimumFarePremium;
        }
        /// <summary>
        /// Method to calculate total fare of car with multiple rides
        /// </summary>
        public double CalculateMonthlyFare(Ride[] rides)
        {
            //calculate Total Fare for multipme rides
            foreach (var total in rides)
            {
                totalFare = totalFare + TotalFare(total.rideType, total.distance, total.time);
            }
            numberOfRides = rides.Length;
            //calculate aggregate of total fare
            averageFare = totalFare / numberOfRides;
            //return a calculate totalfare
            return totalFare;
        }
    }
}