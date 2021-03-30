using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models.ViewModel
{
    public class ParkVehicleCreateViewModel
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "You have to select a vehicle type")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You have to select a vehicle type")]
        public int VehicleTypesId { get; set; }

        [DisplayName("Registration Number")]
        [Required(ErrorMessage = "Registration Number is Required")]
        [Remote(action: "IfRegistrationNumberNotExist", controller: "GarageAsync", ErrorMessage = "Registration number already exist")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Number Of Wheels")]
        [Required(ErrorMessage = "Please enter a Number Of Wheels")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Cannot Select Less Than One")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Year")]
        [StringLength(4, ErrorMessage = "Please enter year as ÅÅÅÅ")]
        [Required(ErrorMessage = "Please enter a Year")]
        public string Year { get; set; }

        [DisplayName("Model")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters")]
        [Required(ErrorMessage = "Please enter a Model")]
        public string Model { get; set; }

        [DisplayName("Make")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters")]
        [Required(ErrorMessage = "Please enter a Make")]
        public string Make { get; set; }

        [DisplayName("Color")]
        [StringLength(15, ErrorMessage = "Cannot be more than 15 characters")]
        [Required(ErrorMessage = "Please enter a Color")]
        public string Color { get; set; }

        [DisplayName("New vehicle type")]
        //[Required(ErrorMessage = "Please enter a vehicle type")]
        //[Remote(action: "IfVehicleTypeNotExist", controller: "GarageAsync", ErrorMessage = "Vehicle type already exist")]
        public string NewVehicleType { get; set; }

        [DisplayName("New vehicle type size")]
        //[Required(ErrorMessage = "Please enter a size of the vehicle type")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Size has to be 1 or more")]
        public int NewVehicleTypeSize { get; set; } = 1;

        [DisplayName("Member name")]
        public string MemberName { get; set; }

        public int MembershipId { get; set; }

        [Required(ErrorMessage = "You have to select a parking place")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You have to select a parking place")]
        public int ParkingPlaceId { get; set; }

        public List<SelectListItem> VehicleTypes { get; set; }
        public bool IsGarageFull { get; set; }
        public List<SelectListItem> FreeParkingPlaces { get; internal set; }
    }
}
