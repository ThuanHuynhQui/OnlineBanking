using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("viewCardAndType")]
    public class viewCardAndType
    {
        [Key]
        public string CardId { get; set; }
        public string AccountId { get; set; }
        public decimal Balance { get; set; }
        public string Pin { get; set; }
        public string OpenDate { get; set; }
        public int TypeId { get; set; }
    }
}
