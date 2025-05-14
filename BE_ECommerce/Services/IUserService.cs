using BE_ECommerce.DTOs;
using BE_ECommerce.Models;

namespace BE_ECommerce.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<User?> UpdateAsync(int id, CreateUserDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
