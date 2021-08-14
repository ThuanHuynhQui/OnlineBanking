using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Models
{
    [Table("vwUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.DateTime)]
        public string DoB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string IdentityId { get; set; }
        public bool Gender { get; set; }
        public string OpenDate { get; set; }
        public bool Role { get; set; }
        public bool Active { get; set; }
        public string Avatar { get; set; }
        [Required]
        public string Password { get; set; }
        
        
        
        
        
        
        
    }
}
