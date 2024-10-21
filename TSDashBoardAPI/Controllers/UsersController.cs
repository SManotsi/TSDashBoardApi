using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Application.Services;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var users = await _usersService.GetUsersByIdAsync(id);
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> GetAllUser()
        {
            return await _usersService.GetAllUserAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] Users users)
        {
            await _usersService.AddUsersAsync(users);
            return CreatedAtAction(nameof(GetUsersById), new { id = users.Id }, users);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers(int id, [FromBody] Users users)
        {
            if (id != users.Id) return BadRequest();

            await _usersService.UpdateUsersAsync(users);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            await _usersService.DeleteUsersAsync(id);
            return NoContent();
        }
    }
}
