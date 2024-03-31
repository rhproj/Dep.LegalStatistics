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
        private readonly IAxesRepositoryBase<AxisDto> _axesRepository;
        public ArbitrationProceedingAxesController(IAxesRepositoryBase<AxisDto> axesRepository)
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

        //[HttpPost("AddToContentAxes")]
        //public async Task<IActionResult> AddToContentAxes([FromBody] AxisDto axisDto)
        //{
        //    var result = await _axesRepository.AddToContentAxes(axisDto);
        //    if (!result)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(result);
        //}
    }
}
