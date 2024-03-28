using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IRepositoryBase<X, T, E> 
        where X : AxesDto 
        where T : ValueDto
        where E : UpsertEntryDto
    {
        Task<IEnumerable<X>> GetTableContentAxes();
        Task<IEnumerable<X>> GetTableActionAxes();

        Task<IEnumerable<T>> GetStatistics(ReportingPeriodDto reportingPeriodDto); //int reportingYear, byte reportingPeriod);

        Task<bool> UpSertEntry(E entryDTO);

        Task<IEnumerable<T>> ResetAllEntriesToZero(ReportingPeriodDto reportingPeriodDto);

        //Task<int> SumEntries(int ordinal, IEnumerable<int> entries);
    }
}
