using Garage_3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage_3.Utils;

namespace Garage_3.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string MemberNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut = DateTime.Now;
        public string ParkedTime {
            get 
            {
                return VehicleHelper.CalculateParkedTime(CheckIn);
            } }

        public double BasePrice = 1.2;
        public double HourlyRate = 2.3;
        public double TotalPrice
        { get
            {
                TimeSpan parkedTime = CheckOut - CheckIn;
                double hoursParked = parkedTime.TotalHours;
                double price = BasePrice + (HourlyRate * hoursParked);
                if (IsPro)
                    price = price * 0.9;
                return price;
            }
        }
        public string CheckInAsString
        {
            get
            {
                 return CheckIn.ToShortDateString();               
            }
        }
        public string CheckOutAsString { 
            get
            {
                return CheckOut.ToShortDateString();
            } }
        public bool IsPro
        { get 
            {


                return
            } }

    }
}
