using Garage_3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string MemberNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string ParkedTime { get; set; }

        public decimal BasePrice { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPrice { get; set; }
        public string CheckInAsString { get; set; }
        public string CheckOutAsString { get; set; }


    }
}
