using Garage_3.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_3.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public int MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleTypeName { get; set; }

        [NotMapped]
        public DateTime CheckInTime { get; set; }

        [NotMapped]
        public string ParkedTime
        {
            get
            {
                return VehicleHelper.CalculateParkedTime(CheckInTime);
            }
        }
    }
}
