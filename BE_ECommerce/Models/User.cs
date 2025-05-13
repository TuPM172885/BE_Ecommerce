﻿namespace BE_ECommerce.Models
{
    public class User
    {
        public int Id { get; set; }  // Oracle sẽ dùng NUMBER
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // "Admin" | "Customer"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
