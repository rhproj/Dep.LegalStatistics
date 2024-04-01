using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;

namespace LegalStatistics.ReportRepository.Repository.ArbitrationProceeding
{
    public class ArbitrationProceedingAxesRepository : I2DAxesRepositoryBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAxesService _axesService;

        public ArbitrationProceedingAxesRepository(AppDbContext dbContext, IMapper mapper, IAxesService axesBase)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _axesService = axesBase;
        }

        public async Task<IEnumerable<AxisDto>> GetLawsuitContentAxes()
        {
            return await _axesService.GetAxesValues<ArbitrationProceeding_LawsuitContent, AxisDto>();
        }
        
        public async Task<IEnumerable<AxisDto>> GetLegalActionAxes()
        {
            return await _axesService.GetAxesValues<ArbitrationProceeding_LegalAction, AxisDto>();
        }

        public async Task<bool> AddToLawsuitContentAxes(AxisUpDto axisDto)
        {
            return await _axesService.AddValueToAxes<ArbitrationProceeding_LawsuitContent, AxisUpDto>(axisDto);
        }
        
        public async Task<bool> AddToLegalActionAxes(AxisUpDto axisDto)
        {
            return await _axesService.AddValueToAxes<ArbitrationProceeding_LegalAction, AxisUpDto>(axisDto);
        }

        public async Task<bool> UpdateContentAxis(AxisDto axisDto)
        {
            return await _axesService.UpdateAxis<ArbitrationProceeding_LawsuitContent, AxisDto>(axisDto);
        }

        public async Task<bool> UpdateActionAxis(AxisDto axisDto)
        {
            return await _axesService.UpdateAxis<ArbitrationProceeding_LegalAction, AxisDto>(axisDto);
        }

        public async Task<bool> RemoveFromContentAxes(int axisId)
        {
            return await _axesService.RemoveFromAxes<ArbitrationProceeding_LawsuitContent>(axisId);
        }

        public async Task<bool> RemoveFromActionAxes(int axisId)
        {
            return await _axesService.RemoveFromAxes<ArbitrationProceeding_LegalAction>(axisId);
        }
    }
}
