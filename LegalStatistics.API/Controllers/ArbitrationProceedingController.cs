﻿using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.ArbitrationProceeding;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetArbitrationProceedingStatistic")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetArbitrationProceedingStatistic([FromQuery] ReportingPeriodDto reportingPeriodDto)
        {
            var result = await _arbitrationRepository.GetStatistics(reportingPeriodDto);   

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
            var result = await _arbitrationRepository.UpSertEntry(entryDto);
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
            var result = await _arbitrationRepository.ResetAllEntriesToZero(reportingPeriodDto);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
