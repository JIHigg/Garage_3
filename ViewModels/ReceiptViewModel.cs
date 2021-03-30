using Garage_3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage_3.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Garage_3.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }
        [DisplayName("Member Number")]
        public string MemberNumber { get; set; }
        [DisplayName("Vehicle Type")]
        public string Type { get; set; }
        [DisplayName("Vehicle Size")]
        public int VehicleSize { get; set; }
        [DisplayName("Member Spaces")]
        public int MemberSpaces { get; set; }
        [DisplayName("Check In Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check Out Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CheckOut  { get { return DateTime.Now; } }
        [DisplayName("Parked Time")]
        public string ParkedTime {
            get
            {
                return VehicleHelper.CalculateParkedTime(CheckIn);
            } }

        public double BasePrice = 50;
        public double HourlyRate = 30;
        
        public bool StayPro { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Pro Discount")]
        public double ProDiscount
        {
            get
            {
                double discount = 1;
                if (IsPro)
                {
                    
                    discount = Math.Min(0.4,( MemberSpaces * 0.1));
                }
                    
                return discount;                    
            }
        }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Pro Savings")]
        public double ProSavings
        { get
            {
                double savings = 0;
                TimeSpan parkedTime = CheckOut - CheckIn;
                double timeParked = parkedTime.TotalHours;


                if(IsPro)
                 savings = (BasePrice + (HourlyRate * timeParked))- TotalPrice ;
                return savings;
            }
        }//Todo Fix Savings


        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Total Price")]
        public double TotalPrice//Todo Fix Discounts for Membership
        { get
            {
                TimeSpan parkedTime = CheckOut - CheckIn;
                
                double hoursParked = parkedTime.TotalHours;
                double sizeCharge = 1;
                double sizeDiscount = 1;
                if (VehicleSize > 1)
                {
                    sizeDiscount = 0.1;
                    sizeCharge = 1 + (0.3 * (VehicleSize - 1));
                }  
                double price = (BasePrice*sizeCharge) + ((HourlyRate * hoursParked)*sizeDiscount);
                return price;
            }
        }

        [DisplayName("Check In ")]
        public string CheckInAsString
        {
            get
            {
                 return CheckIn.ToShortDateString();               
            }
        }
        [DisplayName("Check Out")]
        public string CheckOutAsString { 
            get
            {
                return CheckOut.ToShortDateString();
            } }
        public bool IsPro { get; set; }

    }
}
