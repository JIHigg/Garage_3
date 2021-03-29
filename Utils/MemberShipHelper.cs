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
