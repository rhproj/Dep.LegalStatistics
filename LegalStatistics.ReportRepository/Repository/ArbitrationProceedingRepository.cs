using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository
{
    public class ArbitrationProceedingRepository : IArbitrationProceedingRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArbitrationProceedingRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;        
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValueDto>> GetStatistics(int reportingYear, byte reportingPeriod)
        {
            if (reportingYear < 2000 || reportingPeriod == 0 || reportingPeriod>156)
            {
                throw new ArgumentOutOfRangeException();
            }

            try
            {
                var values = await _dbContext.ArbitrationProceeding_Statistics
                    .Where(s => s.ReportingYear == reportingYear && s.ReportingPeriod == reportingPeriod)
                    .Include(s=>s.LawsuitContent)
                    .Include(s => s.LegalAction)
                    .ToArrayAsync();

                if (values == null || values.Length == 0)
                {
                    var defaultValues = await PopulateWithDefaultValues(reportingYear, reportingPeriod);
                    values = defaultValues.ToArray();
                }

                return _mapper.Map<ArbitrationProceeding_Statistics[], ValueDto[]>(values);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<ArbitrationProceeding_Statistics>> PopulateWithDefaultValues(int reportingYear, byte reportingPeriod)  //ArbitrationProceeding_Statistics[]? result
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
                            ReportingYear = reportingYear, 
                            ReportingPeriod = reportingPeriod,
                            FillDate = DateTime.UtcNow
                        });
                }
            }

            await _dbContext.ArbitrationProceeding_Statistics.AddRangeAsync(values);
            await _dbContext.SaveChangesAsync();
            return values;  
        }

        public async Task<IEnumerable<AxesDto>> GetTableContentAxes()
        {
            try
            {
                var lawsuitContents = await _dbContext.ArbitrationProceeding_LawsuitContent.ToArrayAsync();
                return _mapper.Map<TableAxesBase[], AxesDto[]>(lawsuitContents);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AxesDto>> GetTableActionAxes()
        {
            try
            {
                var legalActions = await _dbContext.ArbitrationProceeding_LegalAction.ToArrayAsync();
                return _mapper.Map<TableAxesBase[], AxesDto[]>(legalActions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpSertEntry(UpsertEntryDto entryDto)
        {
            ArgumentNullException.ThrowIfNull(entryDto);

            try
            {
                var dbEntry = await _dbContext.ArbitrationProceeding_Statistics.FirstOrDefaultAsync(s => s.Id == entryDto.Id);

                dbEntry.Value = entryDto.Value;
                dbEntry.FillDate = DateTime.UtcNow;
                _dbContext.ArbitrationProceeding_Statistics.Update(dbEntry);

                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
