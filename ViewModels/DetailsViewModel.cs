using Garage_3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.ViewModels
{
    public class DetailsViewModel
    {
        public int MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleTypeName { get; set; }
        //public string ParkedTime { get; set; }
    }
}
