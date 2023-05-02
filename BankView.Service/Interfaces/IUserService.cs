using BankView.Domain.Entities;
using BankView.Service.DTOs;
using System.Linq.Expressions;

namespace BankView.Service.Interfaces
{ 
    public interface IUserService
    {
        public ValueTask<UserForResultDto> CreateAsync(UserForCreationDto dto);
        public ValueTask<UserForResultDto> ModifyAsync(UserForUpdateDto dto);
        public ValueTask<bool> RemoveAsync(long id);
        public ValueTask<UserForResultDto> RetriewByIdAsync(long id);
        public ValueTask<List<UserForResultDto>> RetriewAllAsync(Expression<Func<User, bool>> expression = null);
        
    }
}
