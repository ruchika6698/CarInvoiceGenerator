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
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// Method to add rides
        /// </summary>
        public void AddRides(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            //if rideList is false
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                //add rides
                list.AddRange(rides);
                //add userId and Rides
                this.userRides.Add(userID, list);
            }
        }
        /// <summary>
        /// Method to get rides of user
        /// </summary>
        public Ride[] GetRides(string userID)
        {
            return this.userRides[userID].ToArray();
        }
    }
}
