using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaMicroservice.Data;
using LojaMicroservice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LojasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Lojas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loja>>> GetLojas()
        {
            return await _context.Lojas.ToListAsync();
        }

        // GET: api/Lojas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loja>> GetLoja(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }

        // POST: api/Lojas
        [HttpPost]
        public async Task<ActionResult<Loja>> PostLoja(Loja loja)
        {
            _context.Lojas.Add(loja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoja", new { id = loja.Id }, loja);
        }

        // PUT: api/Lojas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoja(int id, Loja loja)
        {
            if (id != loja.Id)
            {
                return BadRequest();
            }

            _context.Entry(loja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LojaExists(id))
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

        // DELETE: api/Lojas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoja(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }

            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LojaExists(int id)
        {
            return _context.Lojas.Any(e => e.Id == id);
        }
    }
}
