using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.Entites
{
    public class Garage
    {
        [Key]
        public int GarageId { get; set; }
        public string GarageName { get; set; }
        public int NumberOfParkingPlaces { get; set; }


        //Navigation
        

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; }
    }
}
