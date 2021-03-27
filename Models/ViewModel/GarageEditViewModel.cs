using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_3.Models.ViewModel
{
    public class GarageEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Type of vehicle")]
        [Required(ErrorMessage = "You have to select a type of vehicle")]
        public string VehicleType { get; set; }

        [DisplayName("Registration number")]
        [Required(ErrorMessage = "Please insert a valid registration number")]
        [Remote(action: "IfRegistrationNumberNotExist", controller: "Vehicles", AdditionalFields = nameof(Id), ErrorMessage = "Registration number already exist")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Color")]
        [Required(ErrorMessage = "Please insert a valid color")]
        [StringLength(20)]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string Color { get; set; }

        [DisplayName("Vehicle manufacture")]
        [Required(ErrorMessage = "Please insert a vehicle manufacture")]
        public string Make { get; set; }

        [DisplayName("Vehicle model")]
        [Required(ErrorMessage = "Please insert a vehicle model")]
        [StringLength(20)]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string Model { get; set; }

        [DisplayName("Number of wheels")]
        [Range(0, 1000, ErrorMessage = "Cannot select less than one")]
        public int NumberOfWheels { get; set; }

        public DateTime CheckIn { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        [NotMapped]
        public bool IsGarageFull { get; set; }

    }
}

    

