using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_3.Models.Entites
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [DisplayName("Registration Number")]
        [Required(ErrorMessage ="Registration Number is Required")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Number Of Wheels")]
        [Required(ErrorMessage ="Please Enter a Number Of Wheels")]
        [Range(1,Int32.MaxValue, ErrorMessage ="Cannot Select Less Than One")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Year")]
        [StringLength(4, ErrorMessage ="Please enter year as ÅÅÅÅ")]
        [Required(ErrorMessage ="Please Enter a Year")]
        public string Year { get; set; }

        [DisplayName("Model")]
        [StringLength(40,ErrorMessage ="Cannot be more than 40 characters")]
        [Required(ErrorMessage ="Please Enter a Model")]
        public string Model { get; set; }

        [DisplayName("Make")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters")]
        [Required(ErrorMessage = "Please Enter a Make")]
        public string Make { get; set; }

        [DisplayName("Color")]
        [StringLength(15, ErrorMessage = "Cannot be more than 15 characters")]
        [Required(ErrorMessage = "Please Enter a Color")]
        public string Color { get; set; }

        [DisplayName("Parking time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", NullDisplayText = "Undefined")]
        public DateTime CheckInTime { get; set; }

        [DisplayName("Leaving time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", NullDisplayText = "Undefined")]
        public DateTime CheckOutTime { get; set; }

        public bool IsParked { get; set; }


        //Navigation
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        public Membership Membership { get; set; }
        public VehicleType VehicleType { get; set; }
        public int? ParkingPlaceId { get; set; }

        public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; }
    }
}
