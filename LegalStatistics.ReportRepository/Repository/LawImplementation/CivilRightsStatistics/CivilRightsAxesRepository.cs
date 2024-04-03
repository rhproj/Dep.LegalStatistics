using AutoMapper;
using LegalStatistics.ReportRepository.DataContext;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Models.LawImplementation.CivilRights;
using LegalStatistics.ReportRepository.Repository.BaseRepository;

namespace LegalStatistics.ReportRepository.Repository.LawImplementation.CivilRightsStatistics
{
    public class CivilRightsAxesRepository : I2DAxesRepositoryBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAxesService _axesService;

        public CivilRightsAxesRepository(AppDbContext dbContext, IMapper mapper, IAxesService axesBase)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _axesService = axesBase;
        }

        public async Task<IEnumerable<AxisDto>> GetLawsuitContentAxes()
        {
            return await _axesService.GetAxesValues<CivilRights_LawsuitContent, AxisDto>();
        }

        public async Task<IEnumerable<AxisDto>> GetLegalActionAxes()
        {
            return await _axesService.GetAxesValues<CivilRights_LegalAction, AxisDto>();
        }

        public async Task<bool> AddToLawsuitContentAxes(AxisUpDto axisDto)
        {
            return await _axesService.AddValueToAxes<CivilRights_LawsuitContent, AxisUpDto>(axisDto);
        }

        public async Task<bool> AddToLegalActionAxes(AxisUpDto axisDto)
        {
            return await _axesService.AddValueToAxes<CivilRights_LegalAction, AxisUpDto>(axisDto);
        }

        public async Task<bool> UpdateContentAxis(AxisDto axisDto)
        {
            return await _axesService.UpdateAxis<CivilRights_LawsuitContent, AxisDto>(axisDto);
        }

        public async Task<bool> UpdateActionAxis(AxisDto axisDto)
        {
            return await _axesService.UpdateAxis<CivilRights_LegalAction, AxisDto>(axisDto);
        }

        public async Task<bool> RemoveFromContentAxes(int axisId)
        {
            return await _axesService.RemoveFromAxes<CivilRights_LawsuitContent>(axisId);
        }

        public async Task<bool> RemoveFromActionAxes(int axisId)
        {
            return await _axesService.RemoveFromAxes<CivilRights_LegalAction>(axisId);
        }
    }
}
