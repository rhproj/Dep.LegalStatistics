using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Models.LawImplementation.CivilRights;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.LawImplementation.CivilRightsStatistics
{
    public class CivilRightsStatisticsRepository : ICivilRightsStatisticsRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IStatisticsDataService _dataService;

        public CivilRightsStatisticsRepository(AppDbContext dbContext, IMapper mapper, IStatisticsDataService dataService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dataService = dataService;
        }

        public async Task<IEnumerable<ValueDto>> GetStatistics(ReportingPeriodDto reportingPeriodDto)
        {
            var values = await _dataService.GetStatistics<CivilRights_Statistics,ReportingPeriodDto,ValueDto>(reportingPeriodDto);
            if (!values.Any())
            {
                return await PopulateWithDefaultValues(reportingPeriodDto);
            }
            return values;
        }

        public async Task<bool> UpSertEntry(UpsertEntryDto entryDto)
        {
            return await _dataService.UpSertEntry<CivilRights_Statistics,UpsertEntryDto>(entryDto);
        }

        public async Task<IEnumerable<ValueDto>> ResetAllEntriesToZero(ReportingPeriodDto reportingPeriodDto)
        {
            return await _dataService.ResetAllEntriesToZero<CivilRights_Statistics,ReportingPeriodDto,ValueDto>(reportingPeriodDto);
        }

        private async Task<IEnumerable<ValueDto>> PopulateWithDefaultValues(ReportingPeriodDto reportingPeriodDto) 
        {
            try
            {
                var contents = await _dbContext.CivilRights_LawsuitsContent.ToArrayAsync();
                var actions = await _dbContext.CivilRights_LegalActions.ToArrayAsync();
                var values = new List<CivilRights_Statistics>();

                for (int i = 0; i < contents.Length; i++)
                {
                    for (int j = 0; j < actions.Length; j++)
                    {
                        values.Add(
                            new CivilRights_Statistics()
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

                await _dbContext.CivilRights_Statistics.AddRangeAsync(values);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<List<CivilRights_Statistics>, List<ValueDto>>(values);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
