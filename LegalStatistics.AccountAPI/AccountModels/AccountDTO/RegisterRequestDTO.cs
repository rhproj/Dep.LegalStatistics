using System.ComponentModel.DataAnnotations;

namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Введённые пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string? Title { get; set; }
        public string? Department { get; set; }
        public string? Role {  get; set; } 
    }
}
