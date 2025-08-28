using Login.Bussines.Interfaces;
using Login.Domain.models;
using Login.models;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class LoginControllers : ControllerBase
    {
        private readonly ICreateUserService _createUserService;
        public LoginControllers (ICreateUserService createUserService) { 
            _createUserService = createUserService; 

        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] LoginRequest loginRequest)
        {
            var model = new UserModel();
            model.Id = Guid.NewGuid().ToString();
            model.Email = loginRequest.Email;
            model.Username = loginRequest.Username;
            model.UserLastName = loginRequest.UserLastName;
            model.Password = loginRequest.Password;
            model.Phone = loginRequest.Phone;
            await _createUserService.CreateUser(model);
            return Created("respuesta", loginRequest);
        }

        [HttpDelete]
        [Route("delete-user")]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }

        [HttpPut]
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
