using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineBanking.Models
{
    [Table("tbService")]
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal Fee { get; set; }
        public ICollection<ServiceCard> ServiceCard { get; set; }
    }
}
