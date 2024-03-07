﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.ArbitrationProceeding
{
    [Table("ArbitrationProceeding.LegalActions")]
    public class ArbitrationProceeding_LegalAction
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
