using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;

namespace LegalStatistics.ReportRepository.Repository.LawImplementation.CivilRightsStatistics
{
    public interface ICivilRightsStatisticsRepository : IStatisticsRepositoryBase<ValueDto, UpsertEntryDto, ReportingPeriodDto>
    {
    }
}