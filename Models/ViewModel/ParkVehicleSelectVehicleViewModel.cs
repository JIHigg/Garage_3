using Garage_3.Models.Entites;
using System.Collections.Generic;
using System.ComponentModel;

namespace Garage_3.Models.ViewModel
{
    public class ParkVehicleSelectVehicleViewModel
    {
        public Membership MemberShip { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        [DisplayName("Member name")]
        public string MemberName {
            get 
            {
                return MemberShip.FirstName + " " + MemberShip.LastName;
            }
        }
    }
}
