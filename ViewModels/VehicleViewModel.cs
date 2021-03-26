using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.ViewModels
{
    public class VehicleViewModel
    {
        [DisplayName("Registration Number")]
        [Required(ErrorMessage = "Registration Number is Required")]
        public string RegistrationNumber { get; set; }

        public DateTime TimeOfArrival { get; set; }

    }
}
