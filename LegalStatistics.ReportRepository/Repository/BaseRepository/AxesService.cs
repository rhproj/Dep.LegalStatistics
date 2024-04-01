using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.BaseModels;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.EntityFrameworkCore;

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
            where TDto : AxisUpDto
        {
            ArgumentNullException.ThrowIfNull(nameof(axisDto));
            try
            {
                axisDto.Ordinal = await SetOrdinal(_dbContext.Set<TValue>(), axisDto.Ordinal);
                axisDto.UptDate = DateTime.UtcNow;

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

        public async Task<bool> UpdateAxis<TValue, TDto>(TDto axisDto)
            where TValue : TableAxesBase
            where TDto : AxisDto
        {
            ArgumentNullException.ThrowIfNull(nameof(axisDto));
            try
            {
                var axisToEdit = await _dbContext.Set<TValue>().FirstOrDefaultAsync(x => x.Id == axisDto.Id);
                if (axisToEdit == null)
                {
                    throw new NullReferenceException();
                }

                axisToEdit.Title = axisDto.Title;
                if (axisDto.Ordinal != axisToEdit.Ordinal)
                {
                    axisToEdit.Ordinal = await SetOrdinal(_dbContext.Set<TValue>(), axisDto.Ordinal);
                }
                axisToEdit.Description = axisDto.Description;
                axisToEdit.UptDate = DateTime.UtcNow;

                _dbContext.Set<TValue>().Update(axisToEdit);
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveFromAxes<TValue>(int axisId) where TValue : TableAxesBase
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
    }
}
