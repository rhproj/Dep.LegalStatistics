using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
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
    public class AxesRepository<T,X> : IAxesRepository<T, X> 
        where T : TableAxesBase
        where X : AxisDto
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<T> dbset;

        public AxesRepository(IMapper mapper, AppDbContext dbContext, DbSet<T> set)   //AppDbContext dbContext,  , DbSet<T> dbset)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            dbset = set;
        }

        public async Task<IEnumerable<X>> GetTableContentAxes()//  DbSet<T> dbset)
        {
            try
            {
                var lawsuitContents = await dbset.ToArrayAsync();
                return _mapper.Map<T[], X[]>(lawsuitContents);
            }
            catch (Exception)
            {
                throw;
            }
        }


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


    }
}
