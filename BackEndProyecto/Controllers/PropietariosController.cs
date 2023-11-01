using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndProyecto.Models;

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public PropietariosController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/Propietarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propietario>>> GetPropietarios()
        {
            {
                var Propietarios = await _context.Propietarios.ToListAsync();

                var propietario = from Propietario in _context.Propietarios
                                  select new
                                  {
                                      cedula = Propietario.CedulaPropietario,
                                      nombre = Propietario.NombrePropietario,
                                      apellido = Propietario.ApellidoPropietario,
                                      telefono = Propietario.TelefonoPropietario,
                                      correo = Propietario.CorreoPropietario,
                                      cuenta = Propietario.CuentaBancariaPropietario,
                                      banco = Propietario.NombreBancoPropietario
                                  };

                return Ok(propietario.ToList());
            }

            // GET: api/Propietarios/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Propietario>> GetPropietario(int id)
        {
          if (_context.Propietarios == null)
          {
              return NotFound();
          }
            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
            {
                return NotFound();
            }

            return propietario;
        }

        // PUT: api/Propietarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropietario(int id, Propietario propietario)
        {
            if (id != propietario.CedulaPropietario)
            {
                return BadRequest();
            }

            _context.Entry(propietario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropietarioExists(id))
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

        // POST: api/Propietarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Propietario>> PostPropietario(Propietario propietario)
        {
          if (_context.Propietarios == null)
          {
              return Problem("Entity set 'CrMercantilContext.Propietarios'  is null.");
          }
            _context.Propietarios.Add(propietario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropietarioExists(propietario.CedulaPropietario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPropietario", new { id = propietario.CedulaPropietario }, propietario);
        }

        // DELETE: api/Propietarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropietario(int id)
        {
            if (_context.Propietarios == null)
            {
                return NotFound();
            }
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }

            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropietarioExists(int id)
        {
            return (_context.Propietarios?.Any(e => e.CedulaPropietario == id)).GetValueOrDefault();
        }
    }
}
