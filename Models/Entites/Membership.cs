using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.Entites
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; }

        [Required(ErrorMessage ="Please Enter a valid Person Number")]
        [DisplayName("Person Number")]
        [StringLength(13,ErrorMessage ="Please enter a valid Person Number ÅÅÅÅMMDD-XXXX")]//Todo Add Validation
        public string Personnummer { get; set; }

        [Required(ErrorMessage ="Please enter a First Name")]
        [DisplayName("First Name")]
        [StringLength(30, ErrorMessage ="First Name cannot be longer than 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [DisplayName("Last Name")]
        [StringLength(100, ErrorMessage ="Last Name cannot be longer than 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter a valid registration date")]
        [DisplayName("Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage ="Please Enter Your Birthday")]
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage ="Please enter your Address")]
        [DisplayName("Street Address")]
        [StringLength(100, ErrorMessage ="Address must be less than 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Please enter a valid Zip/Postal Code")]
        [DisplayName("Zip/Postal Code")]
        [StringLength(10, ErrorMessage ="Zip/Postal Code cannot be more than 10 characters")]
        public string PostNumber { get; set; }

        [Required(ErrorMessage ="Please enter a City")]
        [DisplayName("City")]
        [StringLength(30, ErrorMessage ="City cannot be more than 30 characters")]
        public string City { get; set; }

        [Required(ErrorMessage ="Base Rate is required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Base_Rate { get; set; }

        [Required(ErrorMessage ="Hourly Rate is required")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Hourly_Rate { get; set; }


        //Navigation
        [ForeignKey("Garage")]
        public int GarageId { get; set; }

        public Garage Garage { get; set; }

    }
}
