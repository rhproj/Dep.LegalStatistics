﻿using System.ComponentModel.DataAnnotations;

namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public class ValueDto : DtoBase
    {
        public int Id { get; set; } 
        [Range(1, 300, ErrorMessage = "Допустимый диапазон 1 - 300")]
        public int ContentOrdinal { get; set; }
        [Range(1, 300, ErrorMessage = "Допустимый диапазон 1 - 300")]
        public int ActionOrdinal { get; set; }
        public int ReportingYear { get; set; }
        public byte ReportingPeriod { get; set; }
        public string? Comments { get; set; }
    }
}
