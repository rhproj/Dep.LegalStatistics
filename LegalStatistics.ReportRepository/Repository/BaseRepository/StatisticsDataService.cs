using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public class StatisticsDataService : IStatisticsDataService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public StatisticsDataService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetStatistics<TValue, TPeriod, TDto>(TPeriod reportingPeriodDto)
            where TValue : TableStatisticsBase
            where TPeriod : ReportingPeriodDto
            where TDto : ValueDto
        {
            try
            {
                var values = await _dbContext.Set<TValue>()
                                    .Where(s => s.ReportingYear == reportingPeriodDto.ReportingYear && s.ReportingPeriod == reportingPeriodDto.ReportingPeriod)
                                    .Include(s => s.LawsuitContent)
                                    .Include(s => s.LegalAction)
                                    .ToArrayAsync();

                if (values == null || values.Length == 0)
                {
                    return new List<TDto>();
                }

                return _mapper.Map<TValue[], TDto[]>(values);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpSertEntry<TValue, TEDto>(TEDto entryDto)
            where TValue : TableStatisticsBase
            where TEDto : UpsertEntryDto
        {
            ArgumentNullException.ThrowIfNull(entryDto);
            try
            {
                var dbEntry = await _dbContext.Set<TValue>().FirstOrDefaultAsync(s => s.Id == entryDto.Id);

                dbEntry.Value = entryDto.Value;
                dbEntry.FillDate = DateTime.UtcNow;
                _dbContext.Set<TValue>().Update(dbEntry);

                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TDto>> ResetAllEntriesToZero<TValue, TPeriod, TDto>(TPeriod reportingPeriodDto)
            where TValue : TableStatisticsBase
            where TPeriod : ReportingPeriodDto
            where TDto : ValueDto
        {
            ArgumentNullException.ThrowIfNull(reportingPeriodDto);
            try
            {
                var valuesToReser = await _dbContext.Set<TValue>().Where(s =>
                    s.ReportingYear == reportingPeriodDto.ReportingYear &&
                    s.ReportingPeriod == reportingPeriodDto.ReportingPeriod).ToArrayAsync();

                for (int i = 0; i < valuesToReser.Length; i++)
                {
                    valuesToReser[i].Value = 0;
                }
                _dbContext.Set<TValue>().UpdateRange(valuesToReser);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<TValue[], TDto[]>(valuesToReser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
