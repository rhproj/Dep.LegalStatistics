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
        //public Task<IEnumerable<ArbitrationProceeding_LawsuitContent>> GetLawsuitContents();
        //public Task<IEnumerable<ArbitrationProceeding_LegalAction>> GetLegalActions();
        //public Task<IEnumerable<ArbitrationProceeding_StatisticsDto>> GetArbitrationProceedingStatistic();

        //public Task<bool> UpSertArbitrationProceedingStatistics(ArbitrationProceeding_StatisticsDto entryDTO);

        //public Task<int> ClearEntryArbitrationProceedingStatistics(int entryId);
    }
}
