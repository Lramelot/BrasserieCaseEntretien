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
    public class DevisController : ControllerBase
    {
        private readonly ApiContext _context;

        public DevisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Devis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devis>>> GetDevis()
        {
            return await _context.Devis.ToListAsync();
        }

        // GET: api/Devis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devis>> GetDevis(int id)
        {
            var devis = await _context.Devis.FindAsync(id);

            if (devis == null)
            {
                return NotFound();
            }

            return devis;
        }

        // PUT: api/Devis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevis(int id, Devis devis)
        {
            if (id != devis.DevisId)
            {
                return BadRequest();
            }

            _context.Entry(devis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevisExists(id))
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

        // POST: api/Devis
        [HttpPost]
        public ActionResult<string> PostDevis(Devis devis)
        {
            try
            {
                //Chargement des données connexes
                var beers = _context.Beers.Include(c => c.WholesalerBeer);

                var beerList = beers.Where(c => c.BeerName == devis.BeerDevisName).ToList();
                var wholesaler = _context.Wholesalers.First(c => c.WholesalerId == devis.WholesalerDevisId);

                if (wholesaler == null)
                    throw new NullReferenceException("Le grossiste doit exister");

                if (!wholesaler.WBeersList.Any(c=>c.BeerName.ToLower().Contains(devis.BeerDevisName.ToLower())))
                    throw new NullReferenceException("La bière doit exister et/ou appartenir au grossiste");

                var stock = wholesaler.WBeersList.Where(s => s.BeerName.StartsWith(devis.BeerDevisName)).Count();
                if (devis.StockDevis > stock)
                    throw new ArgumentException("Le stock du grossiste est insufissant et/ou la bière demandé n'est pas vendue");

                if (devis.StockDevis > 10)
                {
                    if (devis.StockDevis > 20)
                        devis.PriceDevis -= (devis.PriceDevis / 100) * 20;
                    else devis.PriceDevis -= (devis.PriceDevis / 100) * 10;
                }

                _context.Devis.Add(devis);

                var apidevis = new ApiDevisDisplay
                {
                    Nom_Grossiste = devis.WholesalerDevisName,
                    Nom_Biere = devis.BeerDevisName,
                    Prix = $"{devis.PriceDevis} €",
                    Date = DateTime.Now,
                    Client_Nom = devis.NameCustomer,
                    Client_Telephone = devis.PhoneCustomer,
                    Stock = string.Format("{0} a {1} {2} en stock", wholesaler.WholesalerName, stock, devis.BeerDevisName)
                };
                return apidevis.GetDevis(apidevis);
            }

            catch (NullReferenceException e)
            {
                throw new NullReferenceException("La commande ou une des propriétés ne peut pas être vide. ");
            }

            catch (Exception e)
            {

                throw new Exception("Une erreur est survenue lors du traitement du devis.");
            }


        }

        // DELETE: api/Devis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevis(int id)
        {
            var devis = await _context.Devis.FindAsync(id);
            if (devis == null)
            {
                return NotFound();
            }

            _context.Devis.Remove(devis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevisExists(int id)
        {
            return _context.Devis.Any(e => e.DevisId == id);
        }
    }
}
