using BankView.Service.DTOs;
using BankView.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankView.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> PostUserAsync(UserForCreationDto dto)
            => Ok(await this.userService.CreateAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutUserAsync(UserForUpdateDto dto)
            => Ok(await this.userService.ModifyAsync(dto));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteUserASync(long id)
            => Ok(await this.userService.RemoveAsync(id));

        [HttpGet("get-by-id/{id:long}")]
        public async Task<IActionResult> GetUserAsync(long id)
            => Ok(await this.userService.RetriewByIdAsync(id));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllUsersAsync()
            => Ok(await this.userService.RetriewAllAsync());

    }
}
