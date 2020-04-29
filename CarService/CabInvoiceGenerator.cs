﻿using System;

namespace CarService
{
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// constants values for costperkm,costpermin,minimumfare
        /// </summary>
        public int costPerkilometer = 10;
        public int costPerMinute = 1;
        public int minimumFare = 5;

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
        public double TotalFare(double distance, double time)
        {
            //calculate Total Fare
            double totalFare = (distance * costPerkilometer) + (time * costPerMinute);
            //if the totalfare is greater than minimum fare then return totalfare
            if (totalFare > minimumFare)
            {
                return totalFare;
            }
            //if the totalfare is less than minimum fare then return totalfare
            return minimumFare;
        }
    }
}