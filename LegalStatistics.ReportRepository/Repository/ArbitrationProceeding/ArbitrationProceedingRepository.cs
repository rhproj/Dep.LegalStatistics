using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.ArbitrationProceeding
{
    public class ArbitrationProceedingRepository : IArbitrationProceedingRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IStatisticsDataService _dataService;

        public ArbitrationProceedingRepository(AppDbContext dbContext, IMapper mapper, IStatisticsDataService dataService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dataService = dataService;
        }

        public async Task<IEnumerable<ValueDto>> GetStatistics(ReportingPeriodDto reportingPeriodDto)
        {
            var values = await _dataService.GetStatistics<ArbitrationProceeding_Statistics, ReportingPeriodDto, ValueDto>(reportingPeriodDto);
            if (!values.Any())
            {
                return await PopulateWithDefaultValues(reportingPeriodDto);
            }
            return values;
        }

        public async Task<bool> UpSertEntry(UpsertEntryDto entryDto)
        {
            return await _dataService.UpSertEntry<ArbitrationProceeding_Statistics, UpsertEntryDto>(entryDto);
        }

        public async Task<IEnumerable<ValueDto>> ResetAllEntriesToZero(ReportingPeriodDto reportingPeriodDto)
        {
            return await _dataService.ResetAllEntriesToZero<ArbitrationProceeding_Statistics, ReportingPeriodDto, ValueDto>(reportingPeriodDto);
        }

        private async Task<IEnumerable<ValueDto>> PopulateWithDefaultValues(ReportingPeriodDto reportingPeriodDto)
        {
            var contents = await _dbContext.ArbitrationProceeding_LawsuitContent.ToArrayAsync();
            var actions = await _dbContext.ArbitrationProceeding_LegalAction.ToArrayAsync();
            var values = new List<ArbitrationProceeding_Statistics>();

            for (int i = 0; i < contents.Length; i++)
            {
                for (int j = 0; j < actions.Length; j++)
                {
                    values.Add(
                        new ArbitrationProceeding_Statistics()
                        {
                            LawsuitContentId = contents[i].Id,
                            LegalActionId = actions[j].Id,
                            Value = 0,
                            ReportingYear = reportingPeriodDto.ReportingYear,
                            ReportingPeriod = reportingPeriodDto.ReportingPeriod,
                            FillDate = DateTime.UtcNow
                        });
                }
            }

            await _dbContext.ArbitrationProceeding_Statistics.AddRangeAsync(values);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<List<ArbitrationProceeding_Statistics>, List<ValueDto>>(values);
        }
    }
}
