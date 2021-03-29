using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_3.Models.ViewModel
{
    public class ParkVehicleSelectParkingPlaceViewModel
    {
        public Membership MemberShip { get; set; }

        [DisplayName("Member name")]
        public string MemberName { get; set; }

        public int MembershipId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        [Required(ErrorMessage = "You have to select a parking place")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You have to select a parking place")]
        public int ParkingPlaceId { get; set; }

        public List<SelectListItem> FreeParkingPlaces { get; set; }
    }
}