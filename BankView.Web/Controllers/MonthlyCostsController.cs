using BankView.Service.DTOs.MonthlyCosts;
using BankView.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankView.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyCostsController : ControllerBase
    {
        private readonly IMonthlyService monthlyService;
        public MonthlyCostsController(IMonthlyService monthlyService)
        {
            this.monthlyService = monthlyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostCostAsync(MonthlyCostForCreationDto dto)
            => Ok(await this.monthlyService.AddAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutCostAsync(MonthlyCostForUpdateDto dto)
            => Ok(await this.monthlyService.ModifyAsync(dto));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllCostsAsync()
            => Ok(await this.monthlyService.RetriewAllAsync());
    }
}
