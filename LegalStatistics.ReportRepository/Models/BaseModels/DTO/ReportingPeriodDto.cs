﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public class ReportingPeriodDto
    {
        [Range(2020, 2050, ErrorMessage = "Допустимый диапазон 2020 - 2050")]
        public int ReportingYear { get; set; }
        [Range(1, 156, ErrorMessage = "Допустимый диапазон 1 - 156")]
        public byte ReportingPeriod { get; set; }
    }
}
