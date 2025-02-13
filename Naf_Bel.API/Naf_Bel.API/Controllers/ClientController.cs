using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _Logger;
        private readonly IClientService _ClientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            this._Logger = logger;
            this._ClientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientRequestDto request)
        {
            var result = await _ClientService.CreateClient(request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? token)
        {
            var result = await this._ClientService.GetAll();
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var result = await this._ClientService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Ulid id)
        {
            var result = await this._ClientService.DeleteById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok();
        }
        
        
    }
}
