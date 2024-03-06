using Microsoft.AspNetCore.Identity;

namespace LegalStatistics.AccountAPI.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? Title { get; set; }
        public string? Department { get; set; }
    }
}
