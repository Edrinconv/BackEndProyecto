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
    public class ContratoArriendosController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public ContratoArriendosController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/ContratoArriendoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoArriendo>>> GetContratoArriendos()
        {
            var contratos = await _context.ContratoArriendos.ToListAsync();
            var arrendatario = await _context.Arrendatarios.ToListAsync();

            var contrato = from ContratoArriendo in _context.ContratoArriendos
                           join Arrendatario in _context.Arrendatarios on ContratoArriendo.CedulaArrendatarioContrato equals Arrendatario.CedulaArrendatario
                           select new
                           {
                               id = ContratoArriendo.IdContrato,
                               inicio = ContratoArriendo.FechaInicioContrato,
                               NombreArrendatario = Arrendatario.NombreArrendatario,
                               apellidoArrendatario = Arrendatario.ApellidoArrendatario,
                               Canon = ContratoArriendo.ValorCanonContrato,
                               Admon = ContratoArriendo.ValorAdministracionContrato
                           };

            return Ok(contrato.ToList());
        }

        // GET: api/ContratoArriendoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratoArriendo>> GetContratoArriendo(int id)
        {
          if (_context.ContratoArriendos == null)
          {
              return NotFound();
          }
            var contratoArriendo = await _context.ContratoArriendos.FindAsync(id);

            if (contratoArriendo == null)
            {
                return NotFound();
            }

            return contratoArriendo;
        }

        // PUT: api/ContratoArriendoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratoArriendo(int id, ContratoArriendo contratoArriendo)
        {
            if (id != contratoArriendo.IdContrato)
            {
                return BadRequest();
            }

            _context.Entry(contratoArriendo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoArriendoExists(id))
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

        // POST: api/ContratoArriendoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContratoArriendo>> PostContratoArriendo(ContratoArriendo contratoArriendo)
        {
          if (_context.ContratoArriendos == null)
          {
              return Problem("Entity set 'CrMercantilContext.ContratoArriendos'  is null.");
          }
            _context.ContratoArriendos.Add(contratoArriendo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContratoArriendoExists(contratoArriendo.IdContrato))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContratoArriendo", new { id = contratoArriendo.IdContrato }, contratoArriendo);
        }

        // DELETE: api/ContratoArriendoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratoArriendo(int id)
        {
            if (_context.ContratoArriendos == null)
            {
                return NotFound();
            }
            var contratoArriendo = await _context.ContratoArriendos.FindAsync(id);
            if (contratoArriendo == null)
            {
                return NotFound();
            }

            _context.ContratoArriendos.Remove(contratoArriendo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoArriendoExists(int id)
        {
            return (_context.ContratoArriendos?.Any(e => e.IdContrato == id)).GetValueOrDefault();
        }
    }
}
