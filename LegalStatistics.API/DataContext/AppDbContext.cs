using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.API.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ArbitrationProceeding_LawsuitContent> ArbitrationProceeding_LawsuitContent { get; set; }
        public DbSet<ArbitrationProceeding_LegalAction> ArbitrationProceeding_LegalAction { get; set; }
        public DbSet<ArbitrationProceeding_Statistics> ArbitrationProceeding_Statistics { get; set; }
    }
}
