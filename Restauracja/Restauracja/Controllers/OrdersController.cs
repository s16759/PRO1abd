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
    public class OrdersController : ControllerBase
    {

        private s16759Context _context;
        public OrdersController(s16759Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Zamowienie);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetOrder(Guid id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zamowienie == null)
                return NotFound();

            return Ok(zamowienie);
        }
    }
}