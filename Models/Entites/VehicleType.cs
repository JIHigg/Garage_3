using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Models.Entites
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }

        [Required(ErrorMessage ="Please enter a valid size")]
        [DisplayName("Size")]
        public decimal Size { get; set; }

        [Required(ErrorMessage ="Please Enter a Vehicle Type")]
        [StringLength(30,ErrorMessage ="Please Enter a Valid Vehicle Type")]
        [DisplayName("Vehicle Type")]
        public string Type_Name { get; set; }

        //Navigation
        
        
    }
}
