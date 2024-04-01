using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface I2DAxesRepositoryBase
    {
        Task<IEnumerable<AxisDto>> GetLawsuitContentAxes();
        Task<IEnumerable<AxisDto>> GetLegalActionAxes();

        Task<bool> AddToLawsuitContentAxes(AxisUpDto axisDto);
        Task<bool> AddToLegalActionAxes(AxisUpDto axisDto);

        Task<bool> UpdateContentAxis(AxisDto axisDto);
        Task<bool> UpdateActionAxis(AxisDto axisDto);

        Task<bool> RemoveFromContentAxes(int axisId);
        Task<bool> RemoveFromActionAxes(int axisId);
    }
}
