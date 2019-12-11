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
        public IActionResult GetOrder()
        {
            return Ok(_context.Zamowienie.FirstOrDefault().ListaPizz);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var pizza = _context.Zamowienie.FirstOrDefault().ListaPizz.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
                return NotFound();
            _context.Zamowienie.FirstOrDefault().ListaPizz.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}