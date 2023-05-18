using System.ComponentModel.DataAnnotations;

namespace NewUpstorm.Service.DTOs
{
    public class UserForPasswordDto
    {
        [Required(ErrorMessage = "Value must not be null or empty")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Old passowrd must not be null or empty!")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage ="New passowrd must not be null or empty!")]
        public string NewPasswword { get; set; }

        [Compare("NewPassowrd")]
        public string ConfirmPassword { get; set; }
    }
}
