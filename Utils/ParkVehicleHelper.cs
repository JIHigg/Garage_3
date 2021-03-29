using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage_3.Utils
{
    public class ParkVehicleHelper
    {
        /// <summary>
        /// Method creates a dropdown list for vehicletypes
        /// </summary>
        /// <param name="lsVehicleTypes">List with vehicle types</param>
        /// <returns>Dropdown for vehicletypes</returns>
        public static List<SelectListItem> CreateVehicleTypeDropDown(List<VehicleType> lsVehicleTypes)
        {
            List<SelectListItem> lsItems = new List<SelectListItem>();
            lsItems.Add(new SelectListItem { Text = "No choice", Value = "0" });

            if (lsVehicleTypes?.Count > 0)
            {
                foreach(VehicleType vt in lsVehicleTypes)
                    lsItems.Add(new SelectListItem { Text = vt.Type_Name, Value = vt.VehicleTypeId.ToString() });

            }

            return lsItems;
        }


        /// <summary>
        ///  Method creates a dropdown list for vehicletypes
        /// </summary>
        /// <param name="lsVehicleTypes">List with vehicle types</param>
        /// <param name="strSelectedVehicleType">Value for vehicle type that shall be selected in the dropw down</param>
        /// <returns>Dropdown for vehicletypes</returns>
        public static List<SelectListItem> CreateVehicleTypeDropDown(List<VehicleType> lsVehicleTypes, string strSelectedVehicleType)
        {
            List<SelectListItem> lsItems = CreateVehicleTypeDropDown(lsVehicleTypes);

            if (!String.IsNullOrWhiteSpace(strSelectedVehicleType))
            {
                var listItem = lsItems.Where(a => a.Value == strSelectedVehicleType).FirstOrDefault();
                if (listItem != null)
                    listItem.Selected = true;
            }

            return lsItems;
        }


        public static List<SelectListItem> CreateParkingPlaceDropDown(List<ParkingPlace> lsParkingPlace)
        {
            List<SelectListItem> lsItems = new List<SelectListItem>();
            lsItems.Add(new SelectListItem { Text = "No choice", Value = "0" });

            if (lsParkingPlace?.Count > 0)
            {
                foreach (ParkingPlace pp in lsParkingPlace)
                    lsItems.Add(new SelectListItem { Text = pp.ParkingPlaceId.ToString(), Value = pp.ParkingPlaceId.ToString() });

            }

            return lsItems;
        }

        public static List<SelectListItem> CreateParkingPlaceDropDown(List<ParkingPlace> lsParkingPlace, string strSelectedParkingPlace)
        {
            List<SelectListItem> lsItems = CreateParkingPlaceDropDown(lsParkingPlace);

            if (!String.IsNullOrWhiteSpace(strSelectedParkingPlace))
            {
                var listItem = lsItems.Where(a => a.Value == strSelectedParkingPlace).FirstOrDefault();
                if (listItem != null)
                    listItem.Selected = true;
            }

            return lsItems;
        }
    }
}