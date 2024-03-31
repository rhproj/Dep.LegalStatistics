using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IAxesService<TValue, TDto>
            where TValue : TableAxesBase
            where TDto : AxisDto
    {
        Task<IEnumerable<TDto>> GetAxesValues<TValue, TDto>()
            where TValue : TableAxesBase
            where TDto : AxisDto;

        Task<bool> AddValueToAxes<TValue, TDto>(TDto axisDto)
            where TValue : TableAxesBase
            where TDto : AxisDto;

        Task<bool> UpdateAxis<TValue, TDto>(int axisId)
            where TValue : TableAxesBase
            where TDto : AxisDto;

        Task<bool> RemoveFromAxes<TValue, TDto>(int axisId)
            where TValue : TableAxesBase
            where TDto : AxisDto;
    }
}