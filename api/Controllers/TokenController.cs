using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}