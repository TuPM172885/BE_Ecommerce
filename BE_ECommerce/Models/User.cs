using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ECommerce.Models
{
    [Table("users")] 
    public class User
    {
        [Key]
        [Column("user_id")] 
        public int user_id { get; set; }
       
        [Column("username")]  
        public string Username { get; set; } = string.Empty;

        [Column("email")]  
        public string Email { get; set; } = string.Empty;

        [Column("password_hash")]  
        public string PasswordHash { get; set; } = string.Empty;

        [Column("created_dtg")]  
        public DateTime CreatedDtg { get; set; } = DateTime.UtcNow;

        [Column("created_by")]
        public string CreatedBy { get; set; } = string.Empty;

    }
}
