using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO
{
    public class ArbitrationProceeding_StatisticsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int LawsuitContentId { get; set; }
        public int LegalActionId { get; set; }
        public byte ReportingPeriod { get; set; }
        public DateTime FillDate { get; set; }
        public string? Comments { get; set; }
    }
}
