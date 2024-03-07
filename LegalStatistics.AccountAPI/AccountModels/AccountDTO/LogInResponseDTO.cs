namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class LogInResponseDTO
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
