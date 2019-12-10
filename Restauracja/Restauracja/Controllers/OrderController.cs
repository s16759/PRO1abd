using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restauracja.Models;

namespace Restauracja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private s16759Context _context;
        public OrderController(s16759Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Zamowienie.First().IdPizzaNavigation);
        }

        /*[HttpGet("{id:Guid}")]
        public IActionResult GetPizza(Guid id)
        {
            var pizza = _context.Zamowienie.First().IdPizzaNavigation.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }*/
    }
}