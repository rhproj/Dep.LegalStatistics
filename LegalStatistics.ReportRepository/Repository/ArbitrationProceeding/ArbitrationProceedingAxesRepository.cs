using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace LegalStatistics.ReportRepository.Repository.ArbitrationProceeding
{
    public class ArbitrationProceedingAxesRepository : AxesRepository<ArbitrationProceeding_LawsuitContent, AxisDto>//IAxesRepository<AxisDto>
    {
        //private readonly AppDbContext _dbContext;
        //private readonly IMapper _mapper;

        public ArbitrationProceedingAxesRepository(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext, DbSe)
        {
        }


        //public ArbitrationProceedingAxesRepository(AppDbContext dbContext, IMapper mapper, 
        //    dbContext.ArbitrationProceeding_LawsuitContent) 
        //    : base(dbContext,mapper, dbContext.ArbitrationProceeding_LawsuitContent)
        //{
        //    //_dbContext = dbContext;
        //    //_mapper = mapper;
        //}

        //public async Task<IEnumerable<AxisDto>> GetTableContentAxes()
        //{
        //    try
        //    {
        //        var lawsuitContents = await _dbContext.ArbitrationProceeding_LawsuitContent.ToArrayAsync();
        //        return _mapper.Map<TableAxesBase[], AxisDto[]>(lawsuitContents);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<AxisDto>> GetTableActionAxes()
        //{
        //    try
        //    {
        //        var legalActions = await _dbContext.ArbitrationProceeding_LegalAction.ToArrayAsync();
        //        return _mapper.Map<TableAxesBase[], AxisDto[]>(legalActions);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<bool> AddToContentAxes(AxisDto axisDto)
        //{
        //    ArgumentNullException.ThrowIfNull(axisDto);
        //    try
        //    {
        //        axisDto.Ordinal = await SetOrdinal(_dbContext.ArbitrationProceeding_LawsuitContent, axisDto.Ordinal);

        //        var axisToAdd = _mapper.Map<AxisDto, ArbitrationProceeding_LawsuitContent>(axisDto);

        //        var result = await _dbContext.ArbitrationProceeding_LawsuitContent.AddAsync(axisToAdd);
        //        return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<bool> AddToActionAxes(AxisDto axisDto)
        //{
        //    ArgumentNullException.ThrowIfNull(axisDto);
        //    try
        //    {
        //        axisDto.Ordinal = await SetOrdinal(_dbContext.ArbitrationProceeding_LegalAction, axisDto.Ordinal);

        //        var axisToAdd = _mapper.Map<AxisDto, ArbitrationProceeding_LegalAction>(axisDto);

        //        var result = await _dbContext.ArbitrationProceeding_LegalAction.AddAsync(axisToAdd);
        //        return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private async Task<int> SetOrdinal<T>(DbSet<T> dbset, int ordinal) where T : TableAxesBase
        {
            var ordinals = await dbset.Select(x => x.Ordinal).ToArrayAsync();
            return ordinals.Contains(ordinal) ? ordinals.Max() + 1 : ordinal;
        }

        public Task<bool> UpdateContentAxis(int axesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateActionAxis(int axesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromContentAxes(int axesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromActionAxes(int axesId)
        {
            throw new NotImplementedException();
        }
    }
}
