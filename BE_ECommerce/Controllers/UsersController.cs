using Microsoft.AspNetCore.Mvc;
using BE_ECommerce.Services;
using BE_ECommerce.Models;
using BE_ECommerce.DTOs;

namespace BE_ECommerce.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Success(users, "Lấy danh sách người dùng thành công");
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFoundResult("Không tìm thấy người dùng");

            return Success(user, "Lấy thông tin người dùng thành công");
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return Error("Dữ liệu không hợp lệ", ModelState);

            var createdUser = await _userService.CreateAsync(dto);
            return Success(createdUser, "Tạo người dùng thành công");
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return Error("Dữ liệu không hợp lệ", ModelState);

            var updatedUser = await _userService.UpdateAsync(id, dto);
            if (updatedUser == null)
                return NotFoundResult("Không tìm thấy người dùng để cập nhật");

            return Success(updatedUser, "Cập nhật người dùng thành công");
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
                return NotFoundResult("Không tìm thấy người dùng để xóa");

            return Success(null, "Xóa người dùng thành công");
        }
    }
}
