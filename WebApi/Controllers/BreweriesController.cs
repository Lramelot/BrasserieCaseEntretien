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
    public class BreweriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public BreweriesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Breweries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweries()
        {
            //   return await _context.Wholesalers.ToListAsync();
            DbSet<Brewery> v_set = _context.Breweries;
            //Chargement des données connexes
            return await v_set.Include(c => c.BBeersList).ToListAsync();
        }

        // GET: api/Breweries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brewery>> GetBrewery(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        // PUT: api/Breweries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(int id, Brewery brewery)
        {
            if (id != brewery.BreweryId)
            {
                return BadRequest();
            }

            _context.Entry(brewery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryExists(id))
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

        // POST: api/Breweries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brewery>> PostBrewery(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrewery", new { id = brewery.BreweryId }, brewery);
        }

        // DELETE: api/Breweries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);
            if (brewery == null)
            {
                return NotFound();
            }

            _context.Breweries.Remove(brewery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreweryExists(int id)
        {
            return _context.Breweries.Any(e => e.BreweryId == id);
        }
    }
}
