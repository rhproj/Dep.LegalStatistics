using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalStatistics.ReportRepository.Repository.BaseRepository
{
    public class AxesService : IAxesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AxesService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAxesValues<TValue, TDto>()
            where TValue : TableAxesBase
            where TDto : AxisDto
        {
            try
            {
                var lawsuitContents = await _dbContext.Set<TValue>().ToArrayAsync();
                return _mapper.Map<TValue[], TDto[]>(lawsuitContents);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddValueToAxes<TValue, TDto>(TDto axisDto)
            where TValue : TableAxesBase
            where TDto : AxisDto
        {
            ArgumentNullException.ThrowIfNull(nameof(axisDto));
            try
            {
                axisDto.Ordinal = await SetOrdinal(_dbContext.Set<TValue>(), axisDto.Ordinal);

                var axisToAdd = _mapper.Map<TDto, TValue>(axisDto);
                await _dbContext.Set<TValue>().AddAsync(axisToAdd);
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> SetOrdinal<TValue>(DbSet<TValue> dbset, int ordinal) where TValue : TableAxesBase
        {
            var ordinals = await dbset.Select(x => x.Ordinal).ToArrayAsync();
            return ordinals.Contains(ordinal) ? ordinals.Max() + 1 : ordinal;
        }

        public async Task<bool> UpdateAxis<TValue, TDto>(TDto axisDto)//int axisId)
            where TValue : TableAxesBase
            where TDto : AxisDto
        {
            ArgumentNullException.ThrowIfNull(nameof(axisDto));
            try
            {
                var axisToEdit = await _dbContext.Set<TValue>().FirstOrDefaultAsync(x => x.Ordinal == Ordinal);
                
                _dbContext.Set<TValue>().Update(axisToEdit);
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveFromAxes<TValue, TDto>(int axisId)
            where TValue : TableAxesBase
            where TDto : AxisDto
        {
            ArgumentNullException.ThrowIfNull(nameof(axisId));
            try
            {
                var axisToEdit = await _dbContext.Set<TValue>().FirstOrDefaultAsync(x => x.Id == axisId);
                _dbContext.Set<TValue>().Remove(axisToEdit);
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region b2
        //public async Task<IEnumerable<AxisDto>> GetLawsuitContentAxes()
        //{
        //    try
        //    {
        //        var lawsuitContents = await _dbContext.Set<TContent>().ToArrayAsync();
        //        return _mapper.Map<TableAxesBase[], AxisDto[]>(lawsuitContents);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //
        //public async Task<IEnumerable<AxisDto>> GetLegalActionAxes()
        //{
        //    try
        //    {
        //        var lawsuitActions = await _dbContext.Set<TAction>().ToArrayAsync();
        //        return _mapper.Map<TableAxesBase[], AxisDto[]>(lawsuitActions);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //
        //public async Task<bool> AddToLawsuitContentAxes(AxisDto axisDto)
        //{
        //    ArgumentNullException.ThrowIfNull(nameof(axisDto));
        //    try
        //    {
        //        var axisToAdd = _mapper.Map<AxisDto, TContent>(axisDto);
        //        await _dbContext.Set<TContent>().AddAsync(axisToAdd);
        //        return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //
        //public async Task<bool> AddToLegalActionAxes(AxisDto axisDto)
        //{
        //    ArgumentNullException.ThrowIfNull(nameof(axisDto));
        //    try
        //    {
        //        var axisToAdd = _mapper.Map<AxisDto, TAction>(axisDto);
        //        await _dbContext.Set<TAction>().AddAsync(axisToAdd);
        //        return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //
        //public async Task<bool> AddTableAxis(AxisDto axisDto)
        //{
        //    await _dbContext.Set<AxisDto>().AddAsync(axisDto);
        //    return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        //} 
        #endregion

        #region b3
        //public AxesRepository(IMapper mapper, AppDbContext dbContext, DbSet<T> set)   //AppDbContext dbContext,  , DbSet<T> dbset)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //    dbset = set;
        //}

        //public async Task<IEnumerable<X>> GetTableContentAxes()   //  DbSet<T> dbset)
        //{
        //    try
        //    {
        //        var lawsuitContents = await dbset.ToArrayAsync();
        //        return _mapper.Map<T[], X[]>(lawsuitContents);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //} 
        #endregion

        #region b4
        //public async Task<IEnumerable<AxisDto>> GetTableContentAxes(DbSet<TableAxesBase> dbset)
        //{
        //    try
        //    {
        //        var lawsuitContents = await dbset.ToArrayAsync();
        //        return _mapper.Map<TableAxesBase[], AxisDto[]>(lawsuitContents);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



        //public async Task<IEnumerable<AxisDto>> GetTableActionAxes()
        //public async Task<IEnumerable<AxisDto>> GetTableContentAxes()
        //{
        //    try
        //    {
        //        var lawsuitContents = await _dbset.ToArrayAsync();
        //        return _mapper.Map<T[], AxisDto[]>(lawsuitContents);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //} 
        #endregion

    }
}
