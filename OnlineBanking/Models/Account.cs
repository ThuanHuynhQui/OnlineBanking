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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string OpenDate { get; set; }
        [Required]
        public bool Role { get; set; }
    }
}
