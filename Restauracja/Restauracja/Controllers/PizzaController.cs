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

        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Update(Guid id, Pizza updatedPizza)
        {
            if (_context.Pizza.Count(e => e.IdPizza == id) == 0)
                return NotFound();
            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }
        
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e=>e.IdPizza==id);
            if (pizza == null)
                return NotFound();
            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}