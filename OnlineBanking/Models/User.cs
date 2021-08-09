using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("tbUser")]
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public string DoB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public ICollection<Account> Account { get; set; }
    }
}
