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

        Task<IEnumerable<T>> GetStatistics(int reportingYear, byte reportingPeriod);

        Task<bool> UpSertEntry(E entryDTO);

        //Task<bool> ClearAllEntries(IEnumerable<int> entries);
        //Task<bool> ClearEntry(int entryId);
        //Task<int> SumEntries(int ordinal, IEnumerable<int> entries);
    }
}
