using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public class AxisDto
    {
        public int Id { get; set; }
        public int Ordinal { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
