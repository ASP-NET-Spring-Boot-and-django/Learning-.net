using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Stock;
using backend.Models;
namespace backend.Mappers
{
    public static class StockMappers
    {
        public static StockDto toStockDto(this Stock stockModel){
            return new StockDto{
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                Name = stockModel.Name,
                Purchase = stockModel.Purchase,
                LastDiv= stockModel.LastDiv,
                MarketCap = stockModel.MarketCap
            };
        }
        public static Stock toStockFromCreateDto(this CreateStockRequestDto stockDto){
            return new Stock{
                Symbol = stockDto.Symbol,
                Name = stockDto.Name,
                Purchase = stockDto.Purchase,
                LastDiv= stockDto.LastDiv,
                MarketCap = stockDto.MarketCap
            };
        }

       
    }
}