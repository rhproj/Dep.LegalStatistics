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
        //IRepositoryBase<TableAxesBase, ArbitrationProceeding_Statistics, UpsertEntryDto>   //: IArbitrationProceedingRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        //public readonly ArbitrationProceeding_LawsuitContent[] lawsuitContent;
        //public readonly ArbitrationProceeding_LegalAction[] legalAction;

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
                result = await PopulateWithDefaultValues(result);
            }
            //trc
            return result;
        }

        public async Task<ArbitrationProceeding_Statistics[]?> PopulateWithDefaultValues(ArbitrationProceeding_Statistics[]? result)
        {
            int contentsCount = await _dbContext.ArbitrationProceeding_LawsuitContent.CountAsync();
            int actionsCount = await _dbContext.ArbitrationProceeding_LegalAction.CountAsync();

            result = new ArbitrationProceeding_Statistics[contentsCount + actionsCount];

            //0000...

            await _dbContext.ArbitrationProceeding_Statistics.AddRangeAsync(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TableAxesBase>> TableContentAxes()
        {
            return await _dbContext.ArbitrationProceeding_LawsuitContent.ToListAsync();
        }

        public async Task<IEnumerable<TableAxesBase>> TableActionAxes()
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
