using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Models
{
    [Table("tbChequeType")]
    public class ChequeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChequeTypeId { get; set; }
        [Required]
        public string ChequeName { get; set; }
        public ICollection<Cheque> Cheque { get; set; }
    }
}
