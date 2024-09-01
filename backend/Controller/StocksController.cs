using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controller
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public StocksController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll(){
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id){
             var stocks= _context.Stocks.Find(id);
             if(stocks==null){
                return NotFound();
             }
             return Ok(stocks);
        }
        
    }
}