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
        private readonly IUserService _userService;
        public LoginControllers (IUserService createUserService) { 
            _userService = createUserService; 

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
            await _userService.CreateUser(model);
            return Created("respuesta", loginRequest);
        }

        [HttpGet]
        [Route("get-user")] 
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _userService.GetUserById(userId);
            return StatusCode(StatusCodes.Status200OK, user);
        }
        
        [HttpGet]
        [Route("getAll-user")]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _userService.GetAllUsers();
            return StatusCode(StatusCodes.Status200OK, user);
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

        
    }
}
