using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LegalStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ArbitrationProceedingAxesController : ControllerBase
    {
        private readonly I2DAxesRepositoryBase<AxisDto> _axesRepository;
        public ArbitrationProceedingAxesController(I2DAxesRepositoryBase<AxisDto> axesRepository)
        {
            _axesRepository = axesRepository;
        }

        [HttpGet("GetLawsuitContentAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetLawsuitContentAxes()
        {
            var result = await _axesRepository.GetLawsuitContentAxes(); //GetTableContentAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("GetLegalActionAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetLegalActionAxes()
        {
            var result = await _axesRepository.GetLegalActionAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost("AddToLawsuitContentAxes")]
        public async Task<IActionResult> AddToLawsuitContentAxes([FromBody] AxisDto axisDto)
        {
            var result = await _axesRepository.AddToLawsuitContentAxes(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("AddToLegalActionAxes")]
        public async Task<IActionResult> AddToLegalActionAxes([FromBody] AxisDto axisDto)
        {
            var result = await _axesRepository.AddToLegalActionAxes(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
