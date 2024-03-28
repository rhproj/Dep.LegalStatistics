using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IRepositoryBase<T, E> 
        where T : ValueDto
        where E : UpsertEntryDto
    {
        Task<IEnumerable<T>> GetStatistics(ReportingPeriodDto reportingPeriodDto);
        Task<bool> UpSertEntry(E entryDTO);
        Task<IEnumerable<T>> ResetAllEntriesToZero(ReportingPeriodDto reportingPeriodDto);
    }
}
