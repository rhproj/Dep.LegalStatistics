using LegalStatistics.ReportRepository.Models.ArbitrationProceeding.DTO;
using LegalStatistics.ReportRepository.Models.ArbitrationProceeding;
using LegalStatistics.ReportRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

            return Ok(result);
        }

    }
}
