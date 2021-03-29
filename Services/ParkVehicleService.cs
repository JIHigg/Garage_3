using Garage_3.Data;
using Garage_3.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage_3.Utils;
using System;

namespace Garage_3.Services
{
    public class ParkVehicleService : IParkVehicleService
    {
        private readonly Garage_3Context m_DbGarage;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public ParkVehicleService(Garage_3Context context)
        {
            m_DbGarage = context;
        }

        /// <summary>
        /// Method return all vehicle types from database
        /// </summary>
        /// <returns>List of all vehicle types</returns>
        public List<VehicleType> GetVehicleTypes()
        {
            return m_DbGarage.VehicleType.AsNoTracking()?.ToList();
        }

        /// <summary>
        /// Method check if vehicle type already exist or not
        /// Not case sensitive
        /// </summary>
        /// <param name="VehicleType">Vehicletype</param>
        /// <returns>Return true if vehicle type already exist else false</returns>
        public bool IsVehicleTypeExisting(string VehicleType)
        {
            bool IsVehicleTypeExisting = false;

            if (!String.IsNullOrWhiteSpace(VehicleType))
            {
                string strTmpVehicleType = VehicleType.Trim();
                strTmpVehicleType = strTmpVehicleType.ToLower();

                var vehicleType = m_DbGarage.VehicleType.Where(a => a.Type_Name.ToLower().Equals(strTmpVehicleType)).FirstOrDefault();
                if (vehicleType != null)
                    IsVehicleTypeExisting = true;
            }

            return IsVehicleTypeExisting;
        }


        /// <summary>
        /// Method read all vehicle types from database
        /// Creates a drop down to select a vehicle type
        /// </summary>
        /// <returns>Return a drop down list of vehicle types</returns>
        public List<SelectListItem> CreateVehicleTypeDropDown()
        {
            List<VehicleType>vehicleTypes = GetVehicleTypes();
            List<SelectListItem> selectListItems = ParkVehicleHelper.CreateVehicleTypeDropDown(vehicleTypes);
            return selectListItems;
        }


        /// <summary>
        /// Method read all vehicle types from database
        /// Creates a drop down to select a vehicle type
        /// </summary>
        /// <param name="strSelectedVehicleType">Value for the vehicle type that shall be selected</param>
        /// <returns>Return a drop down list of vehicle types. One item is selected</returns>
        public List<SelectListItem> CreateVehicleTypeDropDown(string strSelectedVehicleType)
        {
            List<VehicleType> vehicleTypes = GetVehicleTypes();
            List<SelectListItem> selectListItems = ParkVehicleHelper.CreateVehicleTypeDropDown(vehicleTypes, strSelectedVehicleType);
            return selectListItems;
        }


        /// <summary>
        /// Method check if garage is full
        /// </summary>
        /// <returns>true if garage is full. Otherwise it returns false</returns>
        public bool IsGarageFull()
        {
            bool bGarageIsFull = true;

            // Hämta garaget och parkeringsplatserna
            var garage = m_DbGarage.Garage.AsNoTracking().Include("ParkingPlaces").FirstOrDefault();

            if (garage != null && garage.ParkingPlaces != null)
            {
                int iNumberOfParkingPlacesInTheGarage = garage.NumberOfParkingPlaces;

                // Hur många parkerinsplatser är upptagna
                int? iNumberOfOccupiedParkingPlaces = garage.ParkingPlaces?.Where(i => i.IsOccupied)?.Count();

                if(iNumberOfOccupiedParkingPlaces.HasValue)
                {
                    if (iNumberOfOccupiedParkingPlaces.Value < iNumberOfParkingPlacesInTheGarage)
                        bGarageIsFull = false;
                }
            }

            return bGarageIsFull;
        }


        /// <summary>
        /// Method read all free parking places
        /// Creates a drop down to select a free parking place
        /// </summary>
        /// <returns>Return a drop down list of free parking places</returns>
        public List<SelectListItem> CreateFreeParkingPlaceDropDown()
        {
            List<ParkingPlace> parkingPlaces = m_DbGarage.ParkingPlace.AsNoTracking().Where(i => i.IsOccupied == false).ToList();

            List<SelectListItem> selectListItems = ParkVehicleHelper.CreateParkingPlaceDropDown(parkingPlaces);

            return selectListItems;
        }


        /// <summary>
        /// Method read all free parking places
        /// Creates a drop down to select a free parking place
        /// </summary>
        /// <param name="strSelectedParkingPlace">Value for the free parking place that shall be selected</param>
        /// <returns>Return a drop down list of free parking places. One item is selected</returns>
        public List<SelectListItem> CreateFreeParkingPlaceDropDown(string strSelectedParkingPlace)
        {
            List<ParkingPlace> parkingPlaces = m_DbGarage.ParkingPlace.AsNoTracking().Where(i => i.IsOccupied == false).ToList();

            List<SelectListItem> selectListItems = ParkVehicleHelper.CreateParkingPlaceDropDown(parkingPlaces, strSelectedParkingPlace);

            return selectListItems;
        }
    }
}