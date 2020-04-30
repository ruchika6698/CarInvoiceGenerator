using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    public class Ride
    {
        public double distance;
        public double time;
        /// <summary>
        /// constructor for Ride class
        /// </summary>
        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}