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
    public class CouponsController : ControllerBase
    {
        private s16759Context _context;
        public CouponsController(s16759Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCoupons()
        {
            return Ok(_context.Promocja.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCoupon(string id)
        {
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocja.Equals(id));
            if (promocja == null)
                return NotFound();

            return Ok(promocja);
        }
    }
}