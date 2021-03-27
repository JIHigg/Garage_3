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
        public string Type { get; set; }
        public int VehicleSize { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut = DateTime.Now;
        public string ParkedTime {
            get
            {
                return VehicleHelper.CalculateParkedTime(CheckIn);
            } }

        public double BasePrice = 1.2;
        public double HourlyRate = 2.3;

        public double ProDiscount
        {
            get
            {
                double discount = 0;
                if (IsPro)
                {
                    discount = VehicleSize * 0.1;
                }
                    
                return discount;                    
            }
        }
        public double ProSavings { get; set; }//Todo Fix Savings



        public double TotalPrice//Todo Fix Discounts for Membership
        { get
            {
                
                TimeSpan parkedTime = CheckOut - CheckIn;
                double hoursParked = parkedTime.TotalHours;
                double price = BasePrice + (HourlyRate * hoursParked);
                
                    
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
        public bool IsPro { get; set; }

    }
}
