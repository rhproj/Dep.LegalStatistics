using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface I2DAxesRepositoryBase<TDto> where TDto : AxisUptDto 
    {
        Task<IEnumerable<TDto>> GetLawsuitContentAxes(); // DbSet<T> dbset);
        Task<IEnumerable<TDto>> GetLegalActionAxes(); // DbSet<T> dbset);

        Task<bool> AddToLawsuitContentAxes(TDto axisDto);
        Task<bool> AddToLegalActionAxes(TDto axisDto);

        Task<bool> UpdateContentAxis(int axisId);
        Task<bool> UpdateActionAxis(int axisId);

        Task<bool> RemoveFromContentAxes(int axisId);
        Task<bool> RemoveFromActionAxes(int axisId);
    }
}
