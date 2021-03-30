using System;
using System.ComponentModel;

namespace Garage_3.Models.ViewModel
{
    public class GarageVehiclesInfoViewModel
    {
        public int VehicleId { get; set; }

        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Make")]
        public string Make { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Year")]
        public string Year { get; set; }

        [DisplayName("Parking time")]
        public DateTime CheckInTime { get; set; }

        [DisplayName("Leaving time")]
        public DateTime CheckOutTime { get; set; }

        [DisplayName("Parked time")]
        public string ParkedTime { get; set; }
        public int ParkingPlaceId { get; set; }
        public int GarageId { get; set; }
        public bool IsParked { get; set; }
        public int VehicleTypeId { get; set; }

        [DisplayName("Vehicle type")]
        public string VehicleType { get; set; }
        public int MemberShipId { get; set; }

        [DisplayName("First name")]
        public string MemberFirstName { get; set; }

        [DisplayName("Last name")]
        public string MemberLastName { get; set; }

        [DisplayName("Members name")]
        public string MemberName { 
            get {
                return MemberFirstName + " " + MemberLastName;
            } 
        }
    }
}
