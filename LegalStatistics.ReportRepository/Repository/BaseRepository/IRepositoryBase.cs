using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IRepositoryBase<X, T, V> 
        where X : TableAxesBase 
        where T : TableStatisticsBase
        where V : UpsertEntryDto
    {
        Task<IEnumerable<X>> TableContentAxes(); //GetContents();
        Task<IEnumerable<X>> TableActionAxes(); //GetContents();
        //Task<IEnumerable<X>> GetActions();
        Task<IEnumerable<T>> GetStatistics(int reportingYear, byte reportingPeriod);

        Task<bool> UpSertEntry(V entryDTO);

        Task<T[]?> PopulateWithDefaultValues(T[]? statistics);
        //Task<bool> ClearAllEntries(IEnumerable<int> entries);
        // Task<bool> ClearEntry(int entryId);

        //Task<int> SumEntries(int ordinal, IEnumerable<int> entries);
    }
}
