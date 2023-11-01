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
    public class ProyectosController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public ProyectosController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            var Proyectos = await _context.Proyectos.ToListAsync();

            var proyecto = from Proyecto in _context.Proyectos
                           select new
                           {
                               matricula = Proyecto.MatriculaInmobiliariaProyecto,
                               proyecto = Proyecto.NombreProyecto,
                               direccion = Proyecto.DireccionProyecto,
                               estrato = Proyecto.EstratoProyecto,
                               escritura = Proyecto.EscrituraReglamentoProyecto,
                               administrador = Proyecto.AdministradorProyecto,
                               telefono = Proyecto.TelefonoAdministradorProyecto,
                               correo = Proyecto.CorreoAdministradorProyecto
                           };

            return Ok(proyecto.ToList());
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
          if (_context.Proyectos == null)
          {
              return NotFound();
          }
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.MatriculaInmobiliariaProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
          if (_context.Proyectos == null)
          {
              return Problem("Entity set 'CrMercantilContext.Proyectos'  is null.");
          }
            _context.Proyectos.Add(proyecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProyectoExists(proyecto.MatriculaInmobiliariaProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProyecto", new { id = proyecto.MatriculaInmobiliariaProyecto }, proyecto);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            if (_context.Proyectos == null)
            {
                return NotFound();
            }
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoExists(int id)
        {
            return (_context.Proyectos?.Any(e => e.MatriculaInmobiliariaProyecto == id)).GetValueOrDefault();
        }
    }
}
