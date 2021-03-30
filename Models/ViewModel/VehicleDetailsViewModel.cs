using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models.ViewModel
{
    public class VehicleDetailsViewModel
    {
        public int VehicleId { get; set; }

        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Number Of Wheels")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Year")]
        public string Year { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Make")]
        public string Make { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        [DisplayName("Parking time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm:ss}", NullDisplayText = "Undefined")]
        public DateTime CheckInTime { get; set; }

        [DisplayName("Leaving time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm:ss}", NullDisplayText = "Undefined")]
        public DateTime CheckOutTime { get; set; }

        public bool IsParked { get; set; }

        [DisplayName("Parked or not")]
        public string Parked { get; set; }

        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }

        public int MemberShipId { get; set; }
    }
}
