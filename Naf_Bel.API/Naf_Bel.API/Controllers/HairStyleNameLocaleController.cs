using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStyleNameLocaleController : ControllerBase
    {
        private readonly ILogger<HairStyleNameLocaleController> _logger;
        private readonly IHairStyleNameLocaleService _hairStyleNameLocaleService;

        public HairStyleNameLocaleController(ILogger<HairStyleNameLocaleController> logger, IHairStyleNameLocaleService hairStyleNameLocaleService)
        {
            this._logger = logger;
            this._hairStyleNameLocaleService = hairStyleNameLocaleService;
        }

        //POST
        [HttpPost]
        public async Task<IActionResult>  CreateHairStyleName(CreateHairStyleNameLocaleRequestDto request)
        {
            var result = await this._hairStyleNameLocaleService.CreateHairStyleLocalName(request);

            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {

            var result = await this._hairStyleNameLocaleService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Ulid id)
        {

            var result = await this._hairStyleNameLocaleService.DeleteById(id);

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? token)
        {

            var result = await this._hairStyleNameLocaleService.GetAll();

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

    }
}
