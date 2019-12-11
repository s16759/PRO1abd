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

        [HttpGet("{id:Guid}")]
        public IActionResult GetCoupons(Guid id)
        {
            var coupon = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }

        [HttpPost]
        public IActionResult Create(Promocja newPromocja)
        {
            _context.Promocja.Add(newPromocja);
            _context.SaveChanges();

            return StatusCode(201, newPromocja);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Update(Guid id, Promocja updatedPromocja)
        {
            if (_context.Promocja.Count(e => e.IdPromocja == id) == 0)
                return NotFound();
            _context.Promocja.Attach(updatedPromocja);
            _context.Entry(updatedPromocja).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPromocja);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (promocja == null)
                return NotFound();
            _context.Promocja.Remove(promocja);
            _context.SaveChanges();

            return Ok(promocja);
        }
    }
}