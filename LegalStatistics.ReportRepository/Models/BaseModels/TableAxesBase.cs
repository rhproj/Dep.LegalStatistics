using System.ComponentModel.DataAnnotations;

namespace LegalStatistics.ReportRepository.Models.BaseModels
{
    public class TableAxesBase
    {
        [Key]
        public int Id { get; set; }
        public int Ordinal { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime UptDate { get; set; }
    }
}
