using AutoMapper;
using BankView.Data.IRepsitories;
using BankView.Domain.Entities;
using BankView.Service.DTOs.DailyCosts;
using BankView.Service.Exceptions;
using BankView.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankView.Service.Services
{
    public class DailyService : IDailyService
    {
        private readonly IMapper mapper;
        private readonly IRepository<DailyCost> dailyCostRepositoy;
        public DailyService(IRepository<DailyCost> dailyCostRepositoy, IMapper mapper)
        {
            this.dailyCostRepositoy = dailyCostRepositoy;
            this.mapper = mapper;
        }

        public async ValueTask<DailyCostForResultDto> AddAsync(DailyCostForCreationDto dto)
        {
            DailyCost cost = this.mapper.Map<DailyCost>(dto);
            cost.CreatedAt = DateTime.UtcNow;
            var insertedCost = await this.dailyCostRepositoy.InsertAsync(cost);
            await this.dailyCostRepositoy.SaveChangesAsync();
            return this.mapper.Map<DailyCostForResultDto>(insertedCost);
        }

        public async ValueTask<DailyCostForResultDto> ModifyAsync(DailyCostForUpdateDto dto)
        {
            DailyCost updatingCost = await this.dailyCostRepositoy.SelectAsync(t => t.Id == dto.Id);
            if (updatingCost is null)
                throw new CustomException(404, "Daily Cost not found");

            this.mapper.Map(dto, updatingCost);
            updatingCost.UpdatedAt = DateTime.UtcNow;
            await this.dailyCostRepositoy.SaveChangesAsync();
            return this.mapper.Map<DailyCostForResultDto>(updatingCost);
        }

        public async ValueTask<List<DailyCostForResultDto>> RetriewAllAsync()
        {
            var entites = this.dailyCostRepositoy.SelectAll();
            var listedEntities = entites.ToList();
            var result = this.mapper.Map<List<DailyCostForResultDto>>(listedEntities);
            return await Task.FromResult(result);
        }
    }
}
