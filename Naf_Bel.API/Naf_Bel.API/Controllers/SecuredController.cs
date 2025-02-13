using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace nafibel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok("Hello from secured controller");
        }
    }
}
