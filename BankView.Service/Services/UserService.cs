using AutoMapper;
using BankView.Data.IRepsitories;
using BankView.Domain.Entities;
using BankView.Service.DTOs;
using BankView.Service.Exceptions;
using BankView.Service.Interfaces;
using System.Linq.Expressions;

namespace BankView.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        public UserService(IMapper mapper, IRepository<User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }


        public async ValueTask<UserForResultDto> CreateAsync(UserForCreationDto dto)
        {
            var existUser = await this.repository
                .SelectAsync(t => t.FirstaName == dto.FirstaName && t.LastaName == dto.LastaName);

            User mappedUser = mapper.Map<User>(dto);
            mappedUser.CreatedAt = DateTime.UtcNow;
            var result = await this.repository.InsertAsync(mappedUser);
            await this.repository.SaveChangesAsync();
            return this.mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var user = await this.repository.SelectAsync(u => u.Id.Equals(id));
            if (user is null)
                throw new CustomException(404, "User not found");

            await this.repository.DeleteAsync(u => u.Id == id);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<List<UserForResultDto>> RetriewAllAsync(Expression<Func<User, bool>> expression = null)
        {
            if (expression is null)
                expression = (x => true);

            var entities = this.repository.SelectAll();
            entities = entities.Where(expression);

            var filteredUsers = entities.ToList();
            var result = mapper.Map<List<UserForResultDto>>(entities);

            return await Task.FromResult(result);
        }

        public async ValueTask<UserForResultDto> RetriewByIdAsync(long id)
        {
            User user = await this.repository.SelectAsync(
               u => u.Id == id);
            if (user is null)
                throw new CustomException(404, "User not found");

            return mapper.Map<UserForResultDto>(user);
        }

        public async ValueTask<UserForResultDto> ModifyAsync(UserForUpdateDto dto)
        {
            var updatingUser = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
            if (updatingUser is null)
                throw new CustomException(404, "User not found");

            this.mapper.Map(dto, updatingUser);
            updatingUser.UpdatedAt = DateTime.UtcNow;
            await this.repository.SaveChangesAsync();

            return mapper.Map<UserForResultDto>(updatingUser);
        }
    }
}
