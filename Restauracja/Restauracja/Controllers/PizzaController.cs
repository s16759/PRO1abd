using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restauracja.Models;

namespace Restauracja.Controllers
{
    [Route("api/menu/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s16759Context _context;
        public PizzaController(s16759Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetPizza(Guid id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }
    }
}