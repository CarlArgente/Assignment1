using Assignment1.DTOs;
using Assignment1.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> Get() => Ok(await _userRepository.Get());
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetById(int id) => Ok(await _userRepository.GetById(id));
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _userRepository.Create(userDto);
            return Ok(data);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _userRepository.Update(userDto.Id, userDto);
            return Ok(data);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var data = await _userRepository.Delete(id);

            return Ok(data);
        }
    }
}
