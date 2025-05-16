using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BE_ECommerce.Models;
using BE_ECommerce.DTOs;
using Org.BouncyCastle.Asn1.Ocsp;

[ApiController]
[Route("api/Auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;
    private readonly AuthSettings _authSettings;

    public AuthController(AppDbContext context, IConfiguration config, AuthSettings authSettings)
    {
        _context = context;
        _config = config;
        _authSettings = authSettings;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(loginDto.UserName))
                return BadRequest("Username is required.");

            var username = loginDto.UserName.Trim();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                return Unauthorized("Invalid credentials");

            bool isValidPassword = _authSettings.UsePasswordHashing
                ? BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password)
                : loginDto.Password == user.Password;

            if (!isValidPassword)
                return Unauthorized("Invalid credentials");

            string token = GenerateToken(user);

            return Ok(new { accessToken = token });
        }
        catch (Exception ex)
        {
            //_logger?.LogError(ex, "Login error");

            return StatusCode(500, "Something went wrong while processing your request.");
        }
    }


    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.UserData, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
