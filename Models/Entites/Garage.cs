using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models.Entites
{
    public class Garage
    {
        [Key]
        public int GarageId { get; set; }

        [DisplayName("Name of garage")]
        public string GarageName { get; set; }

        [DisplayName("Number of parking places in the garage")]
        public int NumberOfParkingPlaces { get; set; }


        //Navigation
        

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; }
    }
}
