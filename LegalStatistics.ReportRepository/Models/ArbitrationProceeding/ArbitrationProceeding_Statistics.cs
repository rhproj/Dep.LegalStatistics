using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.ArbitrationProceeding
{
    [Table("ArbitrationProceeding.Statistics")]
    public class ArbitrationProceeding_Statistics
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

        public int LawsuitContentId { get; set; }
        [ForeignKey("LawsuitContentId")]
        public ArbitrationProceeding_LawsuitContent LawsuitContent { get; set; }
        public int LegalActionId { get; set; }
        [ForeignKey("LegalActionId")]
        public ArbitrationProceeding_LegalAction LegalAction { get; set; }

        public byte ReportingPeriod { get; set; }
        public DateTime FillDate { get; set; }

        public string? Comments { get; set; }
    }
}
