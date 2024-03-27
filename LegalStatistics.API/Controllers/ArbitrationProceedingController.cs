using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using Microsoft.IdentityModel.Tokens;

namespace LegalStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ArbitrationProceedingController : ControllerBase
    {
        private readonly IArbitrationProceedingRepository _arbitrationRepository;
        public ArbitrationProceedingController(IArbitrationProceedingRepository arbitrationRepository)
        {
            _arbitrationRepository = arbitrationRepository;
        }

        [HttpGet("GetLawsuitContents")]
        public async Task<IActionResult> GetLawsuitContents()
        {
            return Ok();
        }

        [HttpGet("GetArbitrationProceedingStatistic")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetArbitrationProceedingStatistic(int reportingYear, byte reportingPeriod)
        {
            var result = await _arbitrationRepository.GetStatistics(reportingYear, reportingPeriod);

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("UpSertEntry")]
        //[Authorize(Roles = "specialist")]
        public async Task<IActionResult> UpSertEntry([FromBody] UpsertEntryDto entryDto)
        {
            var result = await _arbitrationRepository.UpSertEntry(entryDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("GetTableContentAxes")]
        public async Task<IActionResult> GetTableContentAxes()
        {
            var result = await _arbitrationRepository.GetTableContentAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("GetTableActionAxes")]
        public async Task<IActionResult> GetTableActionAxes()
        {
            var result = await _arbitrationRepository.GetTableActionAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
