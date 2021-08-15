using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("tbFeedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string Content { get; set; }
        public string Reply { get; set; }
        public bool Status { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}
