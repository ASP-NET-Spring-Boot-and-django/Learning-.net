using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
         public String Symbol { get; set; }=string.Empty;
        public String Name { get; set; }=string.Empty;

        public decimal Purchase { get; set; }
    
        public decimal LastDiv {get; set; }

        public long MarketCap{ get; set; }
    }
}