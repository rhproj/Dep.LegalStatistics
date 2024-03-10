using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.BaseModels
{
    public abstract class TableAxesBase
    {
        [Key]
        public int Id { get; set; }
        public int Ordinal { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
