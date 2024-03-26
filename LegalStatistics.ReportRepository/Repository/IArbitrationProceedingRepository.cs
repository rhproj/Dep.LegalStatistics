using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Repository
{
    public interface IArbitrationProceedingRepository : IRepositoryBase<TableAxesBase, ArbitrationProceeding_Statistics, UpsertEntryDto>
    {
    }
}
