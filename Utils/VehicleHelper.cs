using Garage_3.ViewModels;
using Garage_3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garage_3.Models.Entites;

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

        public static List<MembersViewModel> SortByFirstName(List<MembersViewModel> lsVehicles, string sortOrder)
        {
            List<MembersViewModel> lsSortedVehicles = lsVehicles;

            if (lsVehicles != null && lsVehicles.Count > 1)
            {
                if (String.IsNullOrWhiteSpace(sortOrder))
                    sortOrder = "asc";

                if (sortOrder.Equals("desc"))
                    lsSortedVehicles = lsVehicles.OrderByDescending(r => r.FirstName).ToList();
                else
                    lsSortedVehicles = lsVehicles.OrderBy(r => r.FirstName).ToList();
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
                else if (sortBy.Equals("FirstName"))
                    lsSortedVehicles = SortByTimeOfArrival(lsVehicles, sortOrder);
            }

            return lsSortedVehicles;
        }


        /// <summary>
        /// Sorts List of Members
        /// </summary>
        /// <param name="lsVehicles"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static List<MembersViewModel> Sort(List<MembersViewModel> lsMembers, string sortBy, string sortOrder)
        {
            List<MembersViewModel> lsSortedMembers = lsMembers;

            if (!String.IsNullOrWhiteSpace(sortBy))
            {
                 if (sortBy.Equals("FirstName"))
                    lsSortedMembers = SortByFirstName(lsMembers, sortOrder);
            }

            return lsSortedMembers;
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

        /// <summary>
        /// Determines if Member is ProMembership
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        internal static bool IsPro(Membership member)
        {
            DateTime now = DateTime.Now;
            int Age = now.Year - member.Birthdate.Year;
            bool freeTrial =  (now.DayOfYear - member.RegistrationDate.DayOfYear < 30) ;
            bool oldAge = 64 < Age && Age > 67 ;
            bool Pro = false;
            

            if (member.StayPro || oldAge|| freeTrial)
                Pro = true;
            return Pro;
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

        public static int CalculateAge(string personnummer) 
        {
            //Creating birthday from Personnummer
            string bdYear = personnummer.ToCharArray(0, 4).ToString();
            string bdMonth = personnummer.ToCharArray(4, 2).ToString();
            string bdDay = personnummer.ToCharArray(6, 2).ToString();
            string bdayString = $"{bdYear}/{bdMonth}/{bdDay}";
            DateTime Birthday = DateTime.Parse(bdayString);

            //Calculate Age
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday.DayOfYear < today.DayOfYear)
                age--;
            return age;
        }

        public static DateTime ConvertBirthdayFromPersonnummer(string personnummer)
        {
            //Creating birthday from Personnummer
            string bdYear = personnummer.Substring(0,4);
            string bdMonth = personnummer.Substring(4,2);
            string bdDay = personnummer.Substring(6,2);
            string bdayString = $"{bdYear}/{bdMonth}/{bdDay}";
            DateTime Birthday = DateTime.Parse(bdayString);
            return Birthday;
        }


    }
}
