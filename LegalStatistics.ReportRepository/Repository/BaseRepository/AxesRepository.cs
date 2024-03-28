using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public class AxesRepository : IAxesRepository<AxesDto>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AxesRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
    }
}
