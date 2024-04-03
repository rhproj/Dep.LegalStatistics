using LegalStatistics.ReportRepository.Models.LawImplementation.CivilRights;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalStatistics.ReportRepository.Models.BaseModels
{
    public abstract class TableStatisticsBase
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

        public int ReportingYear { get; set; }
        public byte ReportingPeriod { get; set; }
        public DateTime FillDate { get; set; }

        #region  Axes
        public int LawsuitContentId { get; set; }
        [ForeignKey("LawsuitContentId")]
        public CivilRights_LawsuitContent LawsuitContent { get; set; }
        public int LegalActionId { get; set; }
        [ForeignKey("LegalActionId")]
        public CivilRights_LegalAction LegalAction { get; set; } 
        #endregion

        public string? Comments { get; set; }
    }
}
