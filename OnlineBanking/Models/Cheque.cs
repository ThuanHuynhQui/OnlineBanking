﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Models
{
    [Table("tbCheque")]
    public class Cheque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChequeId { get; set; }
        [Required]
        public string CardId { get; set; }
        [Required]
        public int Leaf { get; set; }
        [Required]
        public int ChequeTypeId { get; set; }
    }
}
