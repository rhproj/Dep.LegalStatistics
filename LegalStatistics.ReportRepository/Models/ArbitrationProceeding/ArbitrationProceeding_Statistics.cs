using LegalStatistics.ReportRepository.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalStatistics.ReportRepository.Models.ArbitrationProceeding
{
    [Table("ArbitrationProceeding.Statistics")]
    public class ArbitrationProceeding_Statistics : TableStatisticsBase
    {
        public int LawsuitContentId { get; set; }
        [ForeignKey("LawsuitContentId")]
        public ArbitrationProceeding_LawsuitContent LawsuitContent { get; set; }
        public int LegalActionId { get; set; }
        [ForeignKey("LegalActionId")]
        public ArbitrationProceeding_LegalAction LegalAction { get; set; }

    }
}
