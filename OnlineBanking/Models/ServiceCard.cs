using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("tbServiceCard")]
    public class ServiceCard
    {
        public int ServiceCardId { get; set; }
        public string CardId { get; set; }
        public int ServiceId { get; set; }
        
    }
}
