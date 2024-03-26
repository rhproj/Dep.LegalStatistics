using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ArbitrationProceeding_Statistics>> GetStatistics(int reportingYear, byte reportingPeriod)
        {
            var result = await _dbContext.ArbitrationProceeding_Statistics
                .Where(s=>s.ReportingYear == reportingYear && s.ReportingPeriod == reportingPeriod).ToArrayAsync();

            if (result == null || result.Length == 0)
            {
                var defaultValues = await PopulateWithDefaultValues(reportingYear, reportingPeriod);
                result = defaultValues.ToArray();
            }

            return result;
        }

        public async Task<IEnumerable<ArbitrationProceeding_Statistics>> PopulateWithDefaultValues(int reportingYear, byte reportingPeriod)  //ArbitrationProceeding_Statistics[]? result
        {
            var contents = await _dbContext.ArbitrationProceeding_LawsuitContent.ToArrayAsync();
            var actions = await _dbContext.ArbitrationProceeding_LegalAction.ToArrayAsync();
            var results = new List<ArbitrationProceeding_Statistics>();

            for (int i = 0; i < contents.Length; i++)
            {
                for (int j = 0; j < actions.Length; j++)
                {
                    results.Add(
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

            await _dbContext.ArbitrationProceeding_Statistics.AddRangeAsync(results);
            await _dbContext.SaveChangesAsync();
            return results;
        }

        public async Task<IEnumerable<TableAxesBase>> GetTableContentAxes()
        {
            return await _dbContext.ArbitrationProceeding_LawsuitContent.ToListAsync();
        }

        public async Task<IEnumerable<TableAxesBase>> GetTableActionAxes()
        {
            return await _dbContext.ArbitrationProceeding_LegalAction.ToListAsync();
        }

        public async Task<bool> UpSertEntry(UpsertEntryDto entryDto)
        {
            if (entryDto == null) { throw new ArgumentNullException(nameof(entryDto)); }

            var dbEntry = await _dbContext.ArbitrationProceeding_Statistics.FirstOrDefaultAsync(s=>s.Id == entryDto.Id);

            dbEntry.Value = entryDto.Value;
            dbEntry.FillDate = DateTime.UtcNow;
            _dbContext.ArbitrationProceeding_Statistics.Update(dbEntry);

            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }


        //public async Task<int> ClearEntryArbitrationProceedingStatistics(int entryId)
        //{
        //    return 0;
        //}

        //public async Task<IEnumerable<ArbitrationProceeding_StatisticsDto>> GetArbitrationProceedingStatistic()
        //{
        //    return new List<ArbitrationProceeding_StatisticsDto>();
        //}

        //public async Task<IEnumerable<ArbitrationProceeding_LawsuitContent>> GetLawsuitContents()
        //{
        //    return new List<ArbitrationProceeding_LawsuitContent>();
        //}

        //public async Task<IEnumerable<ArbitrationProceeding_LegalAction>> GetLegalActions()
        //{
        //    return new List<ArbitrationProceeding_LegalAction>();
        //}

        //public async Task<bool> UpSertArbitrationProceedingStatistics(ArbitrationProceeding_StatisticsDto entryDTO)
        //{
        //    return true;
        //}
    }
}
