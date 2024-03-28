using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;

namespace LegalStatistics.ReportRepository.Repository
{
    public interface IArbitrationProceedingRepository : IRepositoryBase<ValueDto, UpsertEntryDto>
    {
    }
}
