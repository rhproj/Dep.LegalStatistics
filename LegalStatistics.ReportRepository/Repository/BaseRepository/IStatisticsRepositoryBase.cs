using LegalStatistics.ReportRepository.Models.BaseModels.DTO;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public interface IStatisticsRepositoryBase<Tdto, Edto, Pdto>  
        where Tdto : DtoBase
        where Edto : DtoBase
        where Pdto : ReportingPeriodDto
    {
        Task<IEnumerable<Tdto>> GetStatistics(Pdto reportingPeriodDto);
        Task<IEnumerable<Tdto>> ResetAllEntriesToZero(Pdto reportingPeriodDto);
        Task<bool> UpSertEntry(Edto entryDTO);
    }
}
