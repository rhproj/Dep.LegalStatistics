using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
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

        public async Task<int> ClearEntryArbitrationProceedingStatistics(int entryId)
        {
            return 0;
        }

        public async Task<IEnumerable<ArbitrationProceeding_StatisticsDto>> GetArbitrationProceedingStatistic()
        {
            return new List<ArbitrationProceeding_StatisticsDto>();
        }

        public async Task<IEnumerable<ArbitrationProceeding_LawsuitContent>> GetLawsuitContents()
        {
            return new List<ArbitrationProceeding_LawsuitContent>();
        }

        public async Task<IEnumerable<ArbitrationProceeding_LegalAction>> GetLegalActions()
        {
            return new List<ArbitrationProceeding_LegalAction>();
        }

        public async Task<bool> UpSertArbitrationProceedingStatistics(ArbitrationProceeding_StatisticsDto entryDTO)
        {
            return true;
        }
    }
}
