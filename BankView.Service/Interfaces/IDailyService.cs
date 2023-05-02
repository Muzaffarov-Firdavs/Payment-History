using BankView.Service.DTOs.DailyCosts;

namespace BankView.Service.Interfaces
{
    public interface IDailyService
    {
        public ValueTask<DailyCostForResultDto> AddAsync(DailyCostForCreationDto dto);
        public ValueTask<DailyCostForResultDto> ModifyAsync(DailyCostForUpdateDto dto);
        public ValueTask<List<DailyCostForResultDto>> RetriewAllAsync();
    }
}
