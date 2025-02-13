using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairDresserController : ControllerBase
    {
        private readonly ILogger<HairDresserController> _logger;
        private readonly IHairDresserService _hairDresserService;

        public HairDresserController(ILogger<HairDresserController> logger, IHairDresserService hairDresserService)
        {
            this._logger = logger;
            this._hairDresserService = hairDresserService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHairDresser(CreateHairDresserRequestDto request)
        {
            var result = await this._hairDresserService.CreateHairDresser(request);

            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? Token)
        {
            var result = await this._hairDresserService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Ulid id)
        {

            var result = await this._hairDresserService.DeleteById(id);

            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var result = await this._hairDresserService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Ulid id, [FromBody] CreateHairDresserRequestDto request)
        {
            var result = await this._hairDresserService.Update(id, request);

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
