using BankView.Service.DTOs.MonthlyCosts;

namespace BankView.Service.Interfaces
{
    public interface IMonthlyService
    {
        public ValueTask<MonthlyCostForResultDto> AddAsync(MonthlyCostForCreationDto dto);
        public ValueTask<MonthlyCostForResultDto> ModifyAsync(MonthlyCostForUpdateDto dto);
        public ValueTask<List<MonthlyCostForResultDto>> RetriewAllAsync();
    }
}
