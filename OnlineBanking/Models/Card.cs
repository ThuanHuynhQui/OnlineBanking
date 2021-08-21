using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Models
{
    [Table("tbCard")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CardId { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public string Pin { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string OpenDate { get; set; }
        [Required]
        public int TypeId { get; set; }
    }
}
