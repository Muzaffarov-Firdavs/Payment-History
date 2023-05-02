using AutoMapper;
using BankView.Data.IRepsitories;
using BankView.Domain.Entities;
using BankView.Service.DTOs.MonthlyCosts;
using BankView.Service.Exceptions;
using BankView.Service.Interfaces;

namespace BankView.Service.Services
{
    public class MonthlyService : IMonthlyService
    {
        private readonly IMapper mapper;
        private readonly IDailyService dailyService;
        private readonly IRepository<MonthlyCost> monthlyCostRepositoy;
        public MonthlyService(IRepository<MonthlyCost> monthlyCostRepositoy,
            IDailyService dailyService,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.dailyService = dailyService;
            this.monthlyCostRepositoy = monthlyCostRepositoy;
        }

        public async ValueTask<MonthlyCostForResultDto> AddAsync(MonthlyCostForCreationDto dto)
        {
            MonthlyCost cost = this.mapper.Map<MonthlyCost>(dto);
            cost.CreatedAt = DateTime.UtcNow;

            var dailyCosts = await this.dailyService.RetriewAllAsync();
            var filteredDailyCosts = dailyCosts.Skip(Math.Max(0, dailyCosts.Count - 30)).ToList();
            foreach (var item in filteredDailyCosts)
                cost.Amount += item.Amount;

            var insertedCost = await this.monthlyCostRepositoy.InsertAsync(cost);
            await this.monthlyCostRepositoy.SaveChangesAsync();
            return this.mapper.Map<MonthlyCostForResultDto>(insertedCost);
        }

        public async ValueTask<MonthlyCostForResultDto> ModifyAsync(MonthlyCostForUpdateDto dto)
        {
            MonthlyCost updatingCost = await this.monthlyCostRepositoy.SelectAsync(t => t.Id == dto.Id);
            if (updatingCost is null)
                throw new CustomException(404, "Daily Cost not found");

            updatingCost.UpdatedAt = DateTime.UtcNow;

            var dailyCosts = await this.dailyService.RetriewAllAsync();
            var filteredDailyCosts = dailyCosts.Skip(Math.Max(0, dailyCosts.Count - 30)).ToList();
            foreach (var item in filteredDailyCosts)
                updatingCost.Amount += item.Amount;

            await this.monthlyCostRepositoy.SaveChangesAsync();
            return this.mapper.Map<MonthlyCostForResultDto>(updatingCost);
        }

        public async ValueTask<List<MonthlyCostForResultDto>> RetriewAllAsync()
        {
            var entites = this.monthlyCostRepositoy.SelectAll();
            var listedEntities = entites.ToList();
            var result = this.mapper.Map<List<MonthlyCostForResultDto>>(listedEntities);
            return await Task.FromResult(result);
        }
    }
}
