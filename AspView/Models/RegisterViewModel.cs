using System.ComponentModel.DataAnnotations;

namespace AspView.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string PasswordCheck { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

    }
}
