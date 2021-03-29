using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Garage_3.Services
{
    public interface IParkVehicleService
    {
        List<VehicleType> GetVehicleTypes();
        bool IsVehicleTypeExisting(string VehicleType);
        List<SelectListItem> CreateVehicleTypeDropDown();
        List<SelectListItem> CreateVehicleTypeDropDown(string strSelectedVehicleType);
        bool IsGarageFull();
        List<SelectListItem> CreateFreeParkingPlaceDropDown();
        List<SelectListItem> CreateFreeParkingPlaceDropDown(string strSelectedParkingPlace);        
    }
}