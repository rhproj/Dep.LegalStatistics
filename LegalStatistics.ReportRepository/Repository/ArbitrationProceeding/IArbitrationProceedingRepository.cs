using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;

namespace LegalStatistics.ReportRepository.Repository.ArbitrationProceeding
{
    public interface IArbitrationProceedingRepository : IStatisticsRepositoryBase<ValueDto, UpsertEntryDto, ReportingPeriodDto>
    {
    }
}
