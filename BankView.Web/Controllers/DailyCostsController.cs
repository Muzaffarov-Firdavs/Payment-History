using BankView.Service.DTOs.DailyCosts;
using BankView.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankView.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyCostsController : ControllerBase
    {
        private readonly IDailyService dailyService;
        public DailyCostsController(IDailyService dailyService)
        {
            this.dailyService = dailyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostUserAsync(DailyCostForCreationDto dto)
            => Ok(await this.dailyService.AddAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutUserAsync(DailyCostForUpdateDto dto)
            => Ok(await this.dailyService.ModifyAsync(dto));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllUsersAsync()
            => Ok(await this.dailyService.RetriewAllAsync());
    }
}
