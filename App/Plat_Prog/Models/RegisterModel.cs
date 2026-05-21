using System.ComponentModel.DataAnnotations;

namespace Plat_prog.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MinLength(6, ErrorMessage = "Hasło musi mieć minimum 6 znaków")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
    }
}
