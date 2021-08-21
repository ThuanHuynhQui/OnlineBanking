using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Models
{
    [Table("tbTransaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [Required]
        public string ReceiverCardId { get; set; }
        [Required]
        public string SenderCardId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required]
        public string Content { get; set; }
        public Boolean Status { get; set; }
        public string Reason { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Time { get; set; }
    }
}
