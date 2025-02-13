using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointmentService _AppointmentService;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _AppointmentService = appointmentService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentRequestDto request)
        {
            var result = await _AppointmentService.CreateAppointment(request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? token)
        {
            var result = await _AppointmentService.GetAll();
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Ulid id)
        {
            var result = await _AppointmentService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Errror);
            }
            return Ok(result.Model);
        }
    }
}
