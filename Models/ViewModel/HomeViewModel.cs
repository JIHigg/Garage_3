using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.ViewModel
{
    public class HomeViewModel
    {
        public string GarageName { get; set; }
        public int NumberOfParkingPlaces { get; set; }
        public int NumberOfVehiclesInGarage { get; internal set; }

        public int Personnummer { get; set; }

    }
}
