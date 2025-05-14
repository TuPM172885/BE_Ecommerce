using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ECommerce.Entities
{
    [Table("USERS")] // Alias bảng trong Oracle
    public class User
    {
        [Key]
        [Column("USER_ID")]
        public int Id { get; set; } // Oracle: NUMBER

        [Required]
        [MaxLength(100)]
        [Column("USERNAME")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [EmailAddress] // Optional: validate email format
        [Column("EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        [Column("PASSWORD_HASH")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("ROLE")]
        public string Role { get; set; } = "Customer"; // "Admin" | "Customer"

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
