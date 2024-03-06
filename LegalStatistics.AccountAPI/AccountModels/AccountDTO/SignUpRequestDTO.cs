using System.ComponentModel.DataAnnotations;

namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class SignUpRequestDTO
    {
        [Required(ErrorMessage = "Email is required")]
        //[RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password is not matched")]
        public string ConfirmPassword { get; set; }

        public string? Title { get; set; }
        public string? Department { get; set; }

        public string? Role { get; set; }
    }
}
