using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Stock
    {
        public int Id {get;set;}
        public String Symbol { get; set; }=string.Empty;
        public String Name { get; set; }=string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
    
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv {get; set; }

        public long MarketCap{ get; set; }

        public List<Comment> Comments { get; set; } =new List<Comment>();
    }
}