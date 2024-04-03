using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Models.BaseModels;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IStatisticsDataService
    {
        Task<IEnumerable<TDto>> GetStatistics<TValue, TPeriod, TDto>(TPeriod reportingPeriodDto)
            where TValue : TableStatisticsBase
            where TPeriod : ReportingPeriodDto
            where TDto : ValueDto;

        Task<bool> UpSertEntry<TValue, TEDto>(TEDto entryDto)
            where TValue : TableStatisticsBase
            where TEDto : UpsertEntryDto;

        Task<IEnumerable<TDto>> ResetAllEntriesToZero<TValue, TPeriod, TDto>(TPeriod reportingPeriodDto)
            where TValue : TableStatisticsBase
            where TPeriod : ReportingPeriodDto
            where TDto : ValueDto;
    }
}