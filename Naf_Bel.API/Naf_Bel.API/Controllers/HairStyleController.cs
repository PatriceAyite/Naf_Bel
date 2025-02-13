using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStyleController : ControllerBase
    {

        private readonly ILogger<HairStyleController> _logger;
        private readonly IHairStyleService _hairStyleService;
        public HairStyleController(ILogger<HairStyleController> logger, IHairStyleService hairStyleService)
        {
            this._logger = logger;
            this._hairStyleService = hairStyleService;
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateHairStyle(CreateHairStyleRequestDto request)
        {

            var result = await this._hairStyleService.CreateHairStyle(request);

            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok(result.Model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {

            var result = await this._hairStyleService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? token)
        {

            var result = await this._hairStyleService.GetAll();

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Ulid id)
        {

            var result = await this._hairStyleService.DeleteById(id);

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Ulid id, [FromBody] CreateHairStyleRequestDto request)
        {
            var result = await this._hairStyleService.Update(id, request);

            if (result.Success)
            {
                return Ok(result.Model);
            }
            else
            {
                return BadRequest(result.Model);
            }

        }
    }
}
