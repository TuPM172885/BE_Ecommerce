using BE_ECommerce.DTOs;

namespace BE_ECommerce.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task UpdateAsync(int id, CreateUserDto dto);
        Task DeleteAsync(int id);
    }

}
