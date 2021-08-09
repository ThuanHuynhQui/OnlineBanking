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
        public int FeedbackId { get; set; }
        public string AccountId { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
