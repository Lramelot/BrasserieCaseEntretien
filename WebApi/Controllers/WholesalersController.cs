using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly ApiContext _context;

        public WholesalersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Wholesalers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wholesaler>>> GetWholesalers()
        {
            //   return await _context.Wholesalers.ToListAsync();
            DbSet<Wholesaler> v_set = _context.Wholesalers;
            //Chargement des données connexes
            return await v_set.Include(c => c.WBeersList).ToListAsync();
        }

        // GET: api/Wholesalers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wholesaler>> GetWholesaler(int id)
        {
            var wholesaler = await _context.Wholesalers.FindAsync(id);

            if (wholesaler == null)
            {
                return NotFound();
            }

            return wholesaler;
        }

        // PUT: api/Wholesalers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWholesaler(int id, Wholesaler wholesaler)
        {
            if (id != wholesaler.WholesalerId)
            {
                return BadRequest();
            }

            _context.Entry(wholesaler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WholesalerExists(id))
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

        // POST: api/Wholesalers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wholesaler>> PostWholesaler(Wholesaler wholesaler)
        {
            _context.Wholesalers.Add(wholesaler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWholesaler", new { id = wholesaler.WholesalerId }, wholesaler);
        }

        // DELETE: api/Wholesalers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWholesaler(int id)
        {
            var wholesaler = await _context.Wholesalers.FindAsync(id);
            if (wholesaler == null)
            {
                return NotFound();
            }

            _context.Wholesalers.Remove(wholesaler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WholesalerExists(int id)
        {
            return _context.Wholesalers.Any(e => e.WholesalerId == id);
        }
    }
}
