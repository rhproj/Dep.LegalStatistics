using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Models.BaseModels.DTO
{
    public abstract class DtoBase
    {
        public int Value { get; set; }
        public DateTime FillDate { get; set; }
    }
}
