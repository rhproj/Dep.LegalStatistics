using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IAxesRepository<T, X> 
        where T : TableAxesBase
        where X : AxisDto 
    {
        Task<IEnumerable<X>> GetTableContentAxes(); // DbSet<T> dbset);
        //Task<IEnumerable<X>> GetTableActionAxes();

        //Task<bool> AddToContentAxes(X axisDto);
        //Task<bool> AddToActionAxes(X axisDto);

        //Task<bool> UpdateContentAxis(int axisId);
        //Task<bool> UpdateActionAxis(int axisId);

        //Task<bool> RemoveFromContentAxes(int axisId);
        //Task<bool> RemoveFromActionAxes(int axisId);
    }
}
