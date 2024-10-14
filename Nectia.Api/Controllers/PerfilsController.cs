using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Nectia.Api.Data;

namespace Nectia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private readonly NectiaDbContext _context;

        public PerfilsController(NectiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfils()
        {
          if (_context.Perfils == null)
          {
              return NotFound();
          }
            return await _context.Perfils.ToListAsync();
        }

        // GET: api/Perfils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
          if (_context.Perfils == null)
          {
              return NotFound();
          }
            var perfil = await _context.Perfils.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Perfils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
          if (_context.Perfils == null)
          {
              return Problem("Entity set 'NectiaDbContext.Perfils'  is null.");
          }
            _context.Perfils.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            if (_context.Perfils == null)
            {
                return NotFound();
            }
            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfils.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            return (_context.Perfils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
