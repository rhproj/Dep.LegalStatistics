using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.LawImplementation.CivilRights;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ArbitrationProceeding_LawsuitContent> ArbitrationProceeding_LawsuitContent { get; set; }
        public DbSet<ArbitrationProceeding_LegalAction> ArbitrationProceeding_LegalAction { get; set; }
        public DbSet<ArbitrationProceeding_Statistics> ArbitrationProceeding_Statistics { get; set; }


        public DbSet<CivilRights_LawsuitContent> CivilRights_LawsuitsContent { get; set; }
        public DbSet<CivilRights_LegalAction> CivilRights_LegalActions { get; set; }
        public DbSet<CivilRights_Statistics> CivilRights_Statistics { get; set; }
    }
}
