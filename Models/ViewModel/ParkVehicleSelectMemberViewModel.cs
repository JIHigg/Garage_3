using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models.ViewModel
{
    public class ParkVehicleSelectMemberViewModel
    {
        [Required(ErrorMessage = "You have to select a member")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You have to select a member")]
        public int MemberShipId { get; set; }

        public List<SelectListItem> Members { get; set; }
    }
}
