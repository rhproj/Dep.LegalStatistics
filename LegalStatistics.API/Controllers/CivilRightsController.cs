using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.LawImplementation.CivilRightsStatistics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LegalStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CivilRightsController : ControllerBase
    {
        private readonly ICivilRightsStatisticsRepository _civilRightsRepository;

        public CivilRightsController(ICivilRightsStatisticsRepository civilRightsRepository)
        {
            _civilRightsRepository = civilRightsRepository;
        }

        [HttpGet("GetCivilRightsStatistic")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetCivilRightsStatistic([FromQuery] ReportingPeriodDto reportingPeriodDto)
        {
            var result = await _civilRightsRepository.GetStatistics(reportingPeriodDto);

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost("UpSertEntry")]
        //[Authorize(Roles = "operative")]
        public async Task<IActionResult> UpSertEntry([FromBody] UpsertEntryDto entryDto)
        {
            var result = await _civilRightsRepository.UpSertEntry(entryDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("ResetAllEntries")]
        //[Authorize(Roles = "operative")]
        public async Task<IActionResult> ResetAllEntries([FromBody] ReportingPeriodDto reportingPeriodDto)
        {
            var result = await _civilRightsRepository.ResetAllEntriesToZero(reportingPeriodDto);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
