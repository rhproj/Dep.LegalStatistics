using System.ComponentModel.DataAnnotations;

namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class LogInRequestDTO
    {
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
