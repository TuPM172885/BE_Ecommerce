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
        public int? UserId { get; set; }
       
        [Column("username")]  
        public string? UserName { get; set; } 

        [Column("email")]  
        public string? Email { get; set; } 

        [Column("password")]  
        public string? Password { get; set; }

        [Column("created_dtg")]  
        public DateTime? CreatedDtg { get; set; } 

        [Column("created_by")]
        public string? CreatedBy { get; set; } 

    }
}
