using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LegalStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CivilRightsAxesController : ControllerBase
    {
        private readonly I2DAxesRepositoryBase _axesRepository;
        public CivilRightsAxesController(I2DAxesRepositoryBase axesRepository)
        {
            _axesRepository = axesRepository;
        }

        [HttpGet("GetLawsuitContentAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetLawsuitContentAxes()
        {
            var result = await _axesRepository.GetLawsuitContentAxes();

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
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> AddToLawsuitContentAxes([FromBody] AxisUpDto axisDto)
        {
            var result = await _axesRepository.AddToLawsuitContentAxes(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("AddToLegalActionAxes")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> AddToLegalActionAxes([FromBody] AxisUpDto axisDto)
        {
            var result = await _axesRepository.AddToLegalActionAxes(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("UpdateContentAxis")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> UpdateContentAxis([FromBody] AxisDto axisDto)
        {
            var result = await _axesRepository.UpdateContentAxis(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("UpdateActionAxis")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> UpdateActionAxis([FromBody] AxisDto axisDto)
        {
            var result = await _axesRepository.UpdateActionAxis(axisDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("RemoveFromContentAxes/{axisId}")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> RemoveFromContentAxes(int axisId)
        {
            var result = await _axesRepository.RemoveFromContentAxes(axisId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("RemoveFromActionAxes/{axisId}")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> RemoveFromActionAxes(int axisId)
        {
            var result = await _axesRepository.RemoveFromActionAxes(axisId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
