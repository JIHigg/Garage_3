using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(4)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Message is Too long")]
        public string Message { get; set; }
    }
}
