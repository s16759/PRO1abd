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
    public class KlientController : ControllerBase
    {
        private s16759Context _context;
        public KlientController(s16759Context context)
        {
            _context = context;
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Update(Guid id, Klient updatedKlient)
        {
            if (_context.Klient.Count(e => e.IdKlient == id) == 0)
                return NotFound();
            _context.Klient.Attach(updatedKlient);
            _context.Entry(updatedKlient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedKlient);
        }
    }
}