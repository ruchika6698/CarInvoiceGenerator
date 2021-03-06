﻿///-----------------------------------------------------------------
///   Class:       Ride
///   Description: create constructor for ridetype,distance and time
///   Author:      Ruchika                   Date: 30/4/2020
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    public class Ride
    {
        public double distance;
        public double time;
        public string rideType;
        /// <summary>
        /// constructor for Ride class
        /// </summary>
        /// <param name="rideType"> Ride types </param>
        /// <param name="distance"> Distance </param>
        /// <param name="time"> Time </param>
        /// <returns> Total Fare </returns>
        public Ride(string rideType, double distance, double time)
        {
            this.rideType = rideType;
            this.distance = distance;
            this.time = time;
        }
    }
}