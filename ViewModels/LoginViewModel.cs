using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter a valid Person Number")]
        [DisplayName("Person Number")]
        [StringLength(13, ErrorMessage = "Please enter a valid Person Number ÅÅÅÅMMDD-XXXX")]//Todo Add Validation
        public string Personnummer { get; set; }
    }
}
