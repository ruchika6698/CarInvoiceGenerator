///-----------------------------------------------------------------
///   Class:       RideRepository
///   Description: RideRepository class to calculate userId and users ride
///   Author:      Ruchika                   Date: 30/4/2020
///-----------------------------------------------------------------

using System.Collections.Generic;

namespace CarService
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// constructor for user rides
        /// </summary>
        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Method to add rides
        /// </summary>
        /// <param name="userID"> User Id </param>
        /// <param name="rides"> Rides </param>
        /// <returns> AddRides </returns>
        public void AddRides(string userID, Ride[] rides)
        {
            bool rideList = userRides.ContainsKey(userID);
            //if rideList is false
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                //add rides
                list.AddRange(rides);
                //add userId and Rides
                userRides.Add(userID, list);
            }
        }

        /// <summary>
        /// Method to get rides of user
        /// </summary>
        /// <param name="userID"> UserID </param>
        /// <returns> GetRides </returns>
        public Ride[] GetRides(string userID)
        {
            return userRides[userID].ToArray();
        }
    }
}
