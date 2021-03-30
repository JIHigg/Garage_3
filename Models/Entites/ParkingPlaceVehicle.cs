using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.Entites
{
    public class ParkingPlaceVehicle
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public int ParkingPlaceId { get; set; }


        // Nav Props

        public Vehicle Vehicle { get; set; }
        public ParkingPlace ParkingPlace { get; set; }
    }
}
