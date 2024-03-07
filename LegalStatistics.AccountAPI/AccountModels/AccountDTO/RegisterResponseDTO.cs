namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class RegisterResponseDTO
    {
        public bool IsRegisterationSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
