using BE_ECommerce.DTOs;
using BE_ECommerce.Models;
using BE_ECommerce.Repositories;
using BE_ECommerce.Utils;


namespace BE_ECommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;
            return new UserDto { Id = u.Id, Username = u.Username, Email = u.Email, Role = u.Role };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = PasswordHelper.HashPassword(dto.Password),
                Role = "Customer"
            };
            var created = await _repo.CreateAsync(user);
            return new UserDto { Id = created.Id, Username = created.Username, Email = created.Email, Role = created.Role };
        }

        public async Task UpdateAsync(int id, CreateUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) throw new Exception("User not found");

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.PasswordHash = PasswordHelper.HashPassword(dto.Password);
            await _repo.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
