using Garage_3.Data;
using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Garage_3.Controllers
{
    /// <summary>
    /// Controller med metoder som skall anropas från Javascript ex. AJAX från remote attributen
    /// </summary>
    public class GarageAsyncController : Controller
    {
        private readonly Garage_3Context m_DbGarage;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public GarageAsyncController(Garage_3Context context)
        {
            m_DbGarage = context;
        }


        //[AcceptVerbs("GET", "POST")]

        /// <summary>
        /// Metoden kontrollerar att det inte finns ett Vehicle med sökta registreringsnumret
        /// </summary>
        /// <param name="RegistrationNumber">Sökt registreringsnummer</param>
        /// <returns>true om det inte finns ett fordon med sökt registreringsnummer. Annars returneras false</returns>
        public JsonResult IfRegistrationNumberNotExist(string RegistrationNumber)
        {
            bool bNotExist = true;

            if (!String.IsNullOrWhiteSpace(RegistrationNumber))
            {
                RegistrationNumber = RegistrationNumber.Trim();
                RegistrationNumber = RegistrationNumber.ToLower();

                var vehicle = m_DbGarage.Vehicle.AsNoTracking().Where(r => r.RegistrationNumber.ToLower().Equals(RegistrationNumber)).FirstOrDefault();
                if (vehicle != null)
                    bNotExist = false;
            }

            return Json(bNotExist);
        }


        /// <summary>
        /// Method check if a vehcile type already exist in the database 
        /// </summary>
        /// <param name="NewVehicleType">Sökt vehicle type</param>
        /// <returns>Return true if vehicle type dosent exist else return false</returns>
        public JsonResult IfVehicleTypeNotExist(string NewVehicleType)
        {
            bool bNotExist = true;

            if(!String.IsNullOrWhiteSpace(NewVehicleType))
            {
                NewVehicleType = NewVehicleType.Trim();
                NewVehicleType = NewVehicleType.ToLower();

                var vehicleType = m_DbGarage.VehicleType.AsNoTracking().Where(t => t.Type_Name.ToLower().Equals(NewVehicleType)).FirstOrDefault();
                if (vehicleType != null)
                    bNotExist = false;
            }

            return Json(bNotExist);
        }


        /// <summary>
        /// Metoden kontrollerar att det inte finns en medlem med sökt personnummer
        /// </summary>
        /// <param name="strPersonnummer">Sökt personnummer</param>
        /// <returns>true om det inte finns en medlem med sökt personnumer. Annars returneras false</returns>
        public JsonResult IsNotMember(string strPersonnummer)
        {
            bool bIsNotMember = true;

            if(!String.IsNullOrWhiteSpace(strPersonnummer))
            {
                strPersonnummer = strPersonnummer.Trim();
                strPersonnummer = strPersonnummer.ToLower();

                Membership member = m_DbGarage.Membership.AsNoTracking().Where(p => p.Personnummer.ToLower().Equals(strPersonnummer)).FirstOrDefault();
                if (member != null)
                    bIsNotMember = false;
            }

            return Json(bIsNotMember);
        }
    }
}