using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaircutController : ControllerBase
    {
        private readonly ILogger<HaircutController> _Logger;
        private readonly IHaircutService _HaircutService;


        public HaircutController(ILogger<HaircutController> logger, IHaircutService haircutService)
        {
            this._Logger = logger;
            this._HaircutService = haircutService;
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircut(CreateHaircutRequestDto request)
        {
            var result = await _HaircutService.CreateHaircut(request);
            if(result == null)
            {
                return NotFound();
            }
            return Ok (result.Model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? Token)
        {
            var result = await _HaircutService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok (result.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var result = await this._HaircutService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok (result.Model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Ulid id)
        {
            var result = await this._HaircutService.DeleteById(id);
            if (!result.Success)
            {
                return BadRequest(result.Errror);
            }
            return Ok();
        }
    }
}
