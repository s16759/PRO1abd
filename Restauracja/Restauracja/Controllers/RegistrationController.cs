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
    public class RegistrationController : ControllerBase
    {
        private s16759Context _context;
        public RegistrationController(s16759Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Klient newKlient)
        {
            _context.Klient.Add(newKlient);
            _context.SaveChanges();

            return StatusCode(201, newKlient);
        }
    }
}