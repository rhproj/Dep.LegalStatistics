using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IStatisticsRepositoryBase<TValue, TEntry, TPeriod>  
        where TValue : DtoBase
        where TEntry : DtoBase
        where TPeriod : ReportingPeriodDto
    {
        Task<IEnumerable<TValue>> GetStatistics(TPeriod reportingPeriodDto);
        Task<IEnumerable<TValue>> ResetAllEntriesToZero(TPeriod reportingPeriodDto);
        Task<bool> UpSertEntry(TEntry entryDTO);
    }
}
