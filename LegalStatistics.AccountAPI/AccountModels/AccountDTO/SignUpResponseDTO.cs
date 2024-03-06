namespace LegalStatistics.AccountAPI.AccountModels.AccountDTO
{
    public class SignUpResponseDTO
    {
        public bool IsRegisterationSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
