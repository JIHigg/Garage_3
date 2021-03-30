using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.Entites
{
    public class ParkingPlace
    {
        [Key]
        public int ParkingPlaceId { get; set; }

        [DisplayName("Is parking place occupied")]
        public bool IsOccupied { get; set; }
        public int Column_position { get; set; }
        public int Row_position { get; set; }
  

        //Navigation

        [ForeignKey("Garage")]
        public int GarageId { get; set; }

        [ForeignKey("Vehicle")]
        public int? VehicleId { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public Garage Garage { get; set; }

        public ICollection<ParkingPlaceVehicle> ParkingPlaceVehicles { get; set; }

    }
}
