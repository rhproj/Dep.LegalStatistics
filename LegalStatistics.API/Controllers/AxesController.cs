using LegalStatistics.ReportRepository.Models.BaseModels.DTO;
using LegalStatistics.ReportRepository.Repository.BaseRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LegalStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AxesController : ControllerBase
    {
        private readonly IAxesRepository<AxesDto> _axesRepository;
        public AxesController(IAxesRepository<AxesDto> axesRepository)
        {
            _axesRepository = axesRepository;
        }

        [HttpGet("GetTableContentAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetTableContentAxes()
        {
            var result = await _axesRepository.GetTableContentAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("GetTableActionAxes")]
        //[Authorize(Roles = "basic")]
        public async Task<IActionResult> GetTableActionAxes()
        {
            var result = await _axesRepository.GetTableActionAxes();

            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
