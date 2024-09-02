using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Stock;
using backend.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StocksController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public StocksController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll(){
            var stocks = await _context.Stocks.ToListAsync();
            stocks.Select(s=>s.toStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id){
             var stocks= await _context.Stocks.FindAsync(id);
             if(stocks==null){
                return NotFound();
             }
             return Ok(stocks.toStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){
            var stackModel=stockDto.toStockFromCreateDto();
            await _context.Stocks.AddAsync(stackModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(getById), new { id = stackModel.Id }, stackModel.toStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockRequestDto updateDto){
            var stockObj=await _context.Stocks.FindAsync(id);
            if(stockObj==null){
                return NotFound();
            }
            stockObj.Symbol=updateDto.Symbol;
            stockObj.Name=updateDto.Name;
            stockObj.MarketCap=updateDto.MarketCap;
            stockObj.Purchase=updateDto.Purchase;
            stockObj.LastDiv=updateDto.LastDiv;
            await _context.SaveChangesAsync();
            return Ok(stockObj.toStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id){
            var stockObj=await _context.Stocks.FindAsync(id);
            if(stockObj==null){
                return NotFound();
            }
            _context.Stocks.Remove(stockObj);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
    
}