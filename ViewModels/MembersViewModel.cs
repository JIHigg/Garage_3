using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.ViewModels
{
    public class MembersViewModel
    {
        public int MembershipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Member Name")]
        public string Name { get; set; }

        [DisplayName("Registered Vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
