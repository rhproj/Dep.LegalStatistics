﻿using System.ComponentModel.DataAnnotations;

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

        public string? Comments { get; set; }
    }
}
