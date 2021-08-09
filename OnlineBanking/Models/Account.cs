using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("tbAccount")]
    public class Account
    {
        public string AccountId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string OpenDate { get; set; }
        public bool Role { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<Card> Card { get; set; }
    }
}
