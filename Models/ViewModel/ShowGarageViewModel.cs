using Garage_3.Models.Entites;
using System.Collections.Generic;
using System.ComponentModel;

namespace Garage_3.Models.ViewModel
{
    public class ShowGarageViewModel
    {
        [DisplayName("Name of garage")]
        public string GarageName { get; set; }

        [DisplayName("Number of parking places in the garage")]
        public int NumberOfParkingPlaces { get; set; }

        public List<Membership> Members { get; set; }

        public List<GarageVehiclesInfoViewModel> VehiclesInfo { get; set; }
    }
}
