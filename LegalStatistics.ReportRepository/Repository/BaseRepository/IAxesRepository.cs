using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IAxesRepository<X> where X : AxesDto
    {
        Task<IEnumerable<X>> GetTableContentAxes();
        Task<IEnumerable<X>> GetTableActionAxes();
    }
}
