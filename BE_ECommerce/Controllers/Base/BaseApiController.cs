using Microsoft.AspNetCore.Mvc;

namespace BE_ECommerce.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success(object data = null, string message = "Thành công")
        {
            return Ok(new
            {
                success = true,
                message,
                data
            });
        }

        protected IActionResult Error(string message = "Có lỗi xảy ra", object errors = null)
        {
            return BadRequest(new
            {
                success = false,
                message,
                errors
            });
        }

        protected IActionResult NotFoundResult(string message = "Không tìm thấy")
        {
            return NotFound(new
            {
                success = false,
                message
            });
        }
    }
}
