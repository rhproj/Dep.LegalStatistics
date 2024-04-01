using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IAxesService
    {
        Task<IEnumerable<TDto>> GetAxesValues<TValue, TDto>()
            where TValue : TableAxesBase
            where TDto : AxisDto;

        Task<bool> AddValueToAxes<TValue, TDto>(TDto axisDto)
            where TValue : TableAxesBase
            where TDto : AxisUpDto;

        Task<bool> UpdateAxis<TValue, TDto>(TDto axisDto)
            where TValue : TableAxesBase
            where TDto : AxisDto;

        Task<bool> RemoveFromAxes<TValue>(int axisId)
            where TValue : TableAxesBase;
    }
}