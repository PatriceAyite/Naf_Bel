using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;

namespace Nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _Logger;
        private readonly IPaymentService _PaymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _Logger = logger;
            _PaymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentRequestDto request)
        {
            var result = await _PaymentService.CreatePayment(request) ;
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Model);
        }
    }
}
