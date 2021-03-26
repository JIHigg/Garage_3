using Garage_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_3.Utils
{
    /// <summary>
    /// Class with helper methods
    /// </summary>
    public class VehicleHelper
    {
        /// <summary>
        /// Method sort list of vehicles by registrationsnumber
        /// Sorting order decides by sortOrder
        /// </summary>
        /// <param name="lsVehicles">List of vehicles that we want to sort/order</param>
        /// <param name="sortOrder">Sort order. Shall be asc or desc. defaul sorting will ve asc</param>
        /// <returns>List of vehicles sorted by registrationnumber</returns>
        public static List<VehicleViewModel> SortByRegistrationNumber(List<VehicleViewModel> lsVehicles, string sortOrder)
        {
            List<VehicleViewModel> lsSortedVehicles = lsVehicles;

            if (lsVehicles != null && lsVehicles.Count > 1)
            {
                if (String.IsNullOrWhiteSpace(sortOrder))
                    sortOrder = "asc";

                if(sortOrder.Equals("desc"))                   
                    lsSortedVehicles = lsVehicles.OrderByDescending(r => r.RegistrationNumber).ToList();
                else
                    lsSortedVehicles = lsVehicles.OrderBy(r => r.RegistrationNumber).ToList();
            }

            return lsSortedVehicles;
        }


        /// <summary>
        /// Method sort list of vehicles by time of arrival
        /// Sorting order decides by sortOrder
        /// </summary>
        /// <param name="lsVehicles">List of vehicles that we want to sort/order</param>
        /// <param name="sortOrder">Sort order. Shall be asc or desc. defaul sorting will ve asc</param>
        /// <returns>list of vehicles sorted by time of arrival</returns>
        public static List<VehicleViewModel> SortByTimeOfArrival(List<VehicleViewModel> lsVehicles, string sortOrder)
        {
            List<VehicleViewModel> lsSortedVehicles = lsVehicles;

            if (lsVehicles != null && lsVehicles.Count > 1)
            {
                if (String.IsNullOrWhiteSpace(sortOrder))
                    sortOrder = "asc";

                if (sortOrder.Equals("desc"))
                    lsSortedVehicles = lsVehicles.OrderByDescending(r => r.TimeOfArrival).ToList();
                else
                    lsSortedVehicles = lsVehicles.OrderBy(r => r.TimeOfArrival).ToList();
            }

            return lsSortedVehicles;
        }


        /// <summary>
        /// Method sort list of vehicles
        /// What attribut we shall sort in decides by sortBy
        /// Sorting order decides by sortOrder
        /// </summary>
        /// <param name="lsVehicles">List of vehicles that we want to sort/order</param>
        /// <param name="sortBy">What attribut shall we sort on. Shall be RegistrationNumber or TimeOfArrival</param>
        /// <param name="sortOrder">Sort order. Shall be asc or desc. defaul sorting will ve asc</param>               
        /// <returns>List of sorted vehicles</returns>
        public static List<VehicleViewModel> Sort(List<VehicleViewModel> lsVehicles, string sortBy, string sortOrder)
        {
            List<VehicleViewModel> lsSortedVehicles = lsVehicles;

            if(!String.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("RegistrationNumber"))
                    lsSortedVehicles = SortByRegistrationNumber(lsVehicles, sortOrder);
                else if (sortBy.Equals("TimeOfArrival"))
                    lsSortedVehicles = SortByTimeOfArrival(lsVehicles, sortOrder);
            }

            return lsSortedVehicles;
        }


        /// <summary>
        /// Method create a text with information about how long ago dtParkedTime
        /// </summary>
        /// <param name="dtParkedTime">Date and time</param>
        /// <returns>String with text</returns>
        public static string CalculateParkedTime(DateTime dtParkedTime)
        {
            int iAddedtoStringBuilder = 0;
            StringBuilder strBuild = new StringBuilder();
            DateTime dtNow = DateTime.Now;

            TimeSpan dtResult = dtNow - dtParkedTime;

            double days = Math.Round(dtResult.TotalDays);
            double hours = Math.Round(dtResult.TotalHours);
            double min = Math.Round(dtResult.TotalMinutes);

            if (days > 0)
            {
                if(days > 1)
                    strBuild.Append((int)days + " days");
                else
                    strBuild.Append((int)days + " day");

                dtResult = dtResult.Subtract(new TimeSpan((int)days, 0, 0, 0));

                hours = Math.Round(dtResult.TotalHours);
                min = Math.Round(dtResult.TotalMinutes);
                iAddedtoStringBuilder++;
            }


            if (hours > 0)
            {
                if (iAddedtoStringBuilder > 0)
                    strBuild.Append(", ");

                if(hours > 1)
                    strBuild.Append((int)hours + " hours");
                else
                    strBuild.Append((int)hours + " hour");

                dtResult = dtResult.Subtract(new TimeSpan(0, (int)hours, 0, 0));

                min = Math.Round(dtResult.TotalMinutes);
                iAddedtoStringBuilder++;
            }


            if (min > 0)
            {
                if (iAddedtoStringBuilder > 0)
                    strBuild.Append(", ");

                if(min > 1)
                    strBuild.Append((int)min + " minutes");
                else
                    strBuild.Append((int)min + " minute");

                iAddedtoStringBuilder++;
            }


            if(iAddedtoStringBuilder == 0)
            {
                strBuild.Append("Recently parked");
            }

            return strBuild.ToString();
        }

        
        internal static double CalculatePrice(DateTime dtParkedTime)
        {
            DateTime dtNow = DateTime.Now;
            TimeSpan dtResult = dtNow - dtParkedTime;
            var minutes = dtResult.TotalMinutes;

            int pricePerMinute = 3;
            //var price = Convert.ToString(minutes * pricePerMinute);
            return (double)(minutes * pricePerMinute);
        }

        public static DateTime CalculateAge(string personnummer) 
        {
            string date = personnummer.ToCharArray(0, 7).ToString();
            TimeSpan age = (DateTime.Now - DateTime.Parse(date));
            int years = age.
        }
    }
}
