using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IAxesRepositoryBase<TValue> where TValue : AxisDto 
    {
        Task<IEnumerable<TValue>> GetLawsuitContentAxes(); // DbSet<T> dbset);
        Task<IEnumerable<TValue>> GetLegalActionAxes(); // DbSet<T> dbset);

        Task<bool> AddToLawsuitContentAxes(TValue axisDto);
        Task<bool> AddToLegalActionAxes(TValue axisDto);

        //Task<bool> UpdateContentAxis(int axisId);
        //Task<bool> UpdateActionAxis(int axisId);

        //Task<bool> RemoveFromContentAxes(int axisId);
        //Task<bool> RemoveFromActionAxes(int axisId);
    }
}
