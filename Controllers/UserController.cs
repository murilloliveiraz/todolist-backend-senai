using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolist_backend_senai.DTOs.UserDTOS;
using todolist_backend_senai.Repositories;

namespace todolist_backend_senai.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest model)
        {
            var user = await _userRepository.Create(model);
            return Ok();
        }
    }
}
