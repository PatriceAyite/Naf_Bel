using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Implematations;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStylePriceController : ControllerBase
    {
        private readonly ILogger<HairStylePriceDto> _Logger;
        private readonly IHairStylepPriceService _hairStylePriseService;

        public HairStylePriceController(ILogger<HairStylePriceDto> logger, IHairStylepPriceService hairStylePrice)
        {
            this._hairStylePriseService = hairStylePrice;
            this._Logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHairStylePrice(CreatHairStylePriceRequestDto request)
        {
            var result = await this._hairStylePriseService.CreateHairStylePrice(request);

            if (!result.Success)
            {
                return BadRequest();
            }
            return Ok(result.Model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string? token)
        {
            var result = await this._hairStylePriseService.Getall();

            if (!result.Success)
            {
                return BadRequest();
            }
            return Ok(result.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var result = await _hairStylePriseService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Ulid id)
        {
            var result = await this._hairStylePriseService.Delete(id);

            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok();
        }
    }
}
