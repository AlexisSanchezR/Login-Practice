using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class LoginControllers : ControllerBase
    {
        [HttpPost("create-user")]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser()
        {
            return Created();
        }

        [HttpPost]
        [Route("delete-user")]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }

        [HttpPost]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpGet]
        [Route("get-user")]
        public async Task<IActionResult> GetUser()
        {
            return StatusCode(StatusCodes.Status200OK, new List<int> () );
        }
    }
}
