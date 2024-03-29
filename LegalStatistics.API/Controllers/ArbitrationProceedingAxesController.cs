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
        private readonly IAxesRepository<ArbitrationProceeding_LawsuitContent, AxisDto> _axesRepository;
        public ArbitrationProceedingAxesController(IAxesRepository<ArbitrationProceeding_LawsuitContent, AxisDto> axesRepository)
        {
            _axesRepository = axesRepository;
        }

        [HttpGet("GetTableContentAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetTableContentAxes()
        {
            var result = await _axesRepository.GetTableContentAxes(); //GetTableContentAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }

        //[HttpGet("GetTableActionAxes")]
        ////[Authorize(Roles = "basic")]
        //public async Task<IActionResult> GetTableActionAxes()
        //{
        //    var result = await _axesRepository.GetTableActionAxes();

        //    if (result.IsNullOrEmpty())
        //    {
        //        return NoContent();
        //    }
        //    return Ok(result);
        //}

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
