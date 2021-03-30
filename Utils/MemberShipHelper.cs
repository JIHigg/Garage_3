using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_3.Utils
{
    public class MemberShipHelper
    {
        /// <summary>
        /// Method return a members typ of membership.
        /// Can be Pro membership or Member
        /// </summary>
        /// <param name="membership">Information about a member</param>
        /// <returns></returns>
        public static string GetTypeOfMemberShip(Membership membership)
        {
            string strTypeOfMember = "Member";

            DateTime dtNow = DateTime.Now;
            DateTime dtEnd = DateTime.Parse($"{dtNow.Year}-{dtNow.Month}-{dtNow.Day} 23:59:59");
            DateTime dtStart = DateTime.Parse($"{dtNow.Year}-{dtNow.Month}-{dtNow.Day} 00:00:00");

            // First we test if member is between 65 and 67 years old. Then it is Pro membership
            if (membership.Birthdate <= dtStart.AddYears(-65))
            {// Member is 65 over years old. 
                // Everyone over 65 receives 2 years of pro membership.

                if (membership.RegistrationDate >= dtEnd.AddYears(-2))
                    strTypeOfMember = "Pro membership";
            }
            else
            {// Member isnt 65 years old. Check registration date
                // Pro membership is automatic upon registration. Valid for 30 days.Then Member

                if (membership.RegistrationDate >= dtEnd.AddDays(-30))
                    strTypeOfMember = "Pro membership";
            }

            return strTypeOfMember;
        }

        /// <summary>
        /// Method creates a dropdown list for members
        /// </summary>
        /// <param name="lsVehicleTypes">List with members</param>
        /// <returns>Dropdown for members</returns>
        public static List<SelectListItem> CreateVehicleTypeDropDown(List<Membership> lsMembers)
        {
            List<SelectListItem> lsItems = new List<SelectListItem>();
            lsItems.Add(new SelectListItem { Text = "No choice", Value = "0" });

            if (lsMembers?.Count > 0)
            {
                foreach (Membership ms in lsMembers)
                    lsItems.Add(new SelectListItem { Text = ms.FirstName + " " + ms.LastName, Value = ms.MembershipId.ToString() });
            }

            return lsItems;
        }


        /// <summary>
        ///  Method creates a dropdown list for members
        /// </summary>
        /// <param name="lsVehicleTypes">List with members</param>
        /// <param name="strSelectedVehicleType">Value for member that shall be selected in the dropw down</param>
        /// <returns>Dropdown for members</returns>
        public static List<SelectListItem> CreateVehicleTypeDropDown(List<Membership> lsMembers, string strSelectedMember)
        {
            List<SelectListItem> lsItems = CreateVehicleTypeDropDown(lsMembers);

            if (!String.IsNullOrWhiteSpace(strSelectedMember))
            {
                var listItem = lsItems.Where(a => a.Value == strSelectedMember).FirstOrDefault();
                if (listItem != null)
                    listItem.Selected = true;
            }

            return lsItems;
        }
    }
}
