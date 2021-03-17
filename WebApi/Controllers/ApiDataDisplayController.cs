using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDataDisplayController : ControllerBase
    {
        private readonly ApiContext _context;

        public ApiDataDisplayController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/ApiDataDisplay
        [HttpGet]
        public IEnumerable<ApiDataAllDipslay> Get()
        {
            var beer = _context.Beers;

            //Chargement des données connexes
            beer.Include(c => c.WholesalerBeer);
            var v_query = beer.Include(c => c.BreweryBeer);

            return v_query.Select(w => new ApiDataAllDipslay
            {
                Nom_Biere = w.BeerName,
                Degree_Alcool = $"{w.Degree} %",
                Prix = $"{w.Price} €",
                Nom_Brasserie = w.BreweryBeer.BreweryName,
                Nom_Grossiste = w.WholesalerBeerName,
            }); 
        }

        // GET api/<ApiDataDisplay>/5
        [HttpGet("{id}")]
        public ApiDataDipslay Get(int id)
        {
            var beer = _context.Beers.Find(id);
            var beers = _context.Beers.Include(c => c.WholesalerBeer);

            var beerList = beers.Where(c => c.BeerName == beer.BeerName).ToList();
            //var wholesaler = _context.Wholesalers.Find(beer.WholesalerBeerId);
            var wholesaler = _context.Wholesalers.First(c => c.WholesalerId == beer.WholesalerBeerId);
            var brewery = _context.Breweries.Find(beer.BreweryBeerId);
            var stock = wholesaler.WBeersList.Where(s => s.BeerName.ToLower().StartsWith(beer.BeerName.ToLower())).Count();

            return new ApiDataDipslay
            {
                Nom_Biere = beer.BeerName,
                Degree_Alcool = $"{beer.Degree} %",
                Prix = $"{beer.Price} €",
                Nom_Brasserie = brewery.BreweryName,
                Nom_Grossiste = wholesaler.WholesalerName,
                Stock = string.Format("{0} a {1} {2} en stock", wholesaler.WholesalerName, stock,beer.BeerName)
            };
        }
    }
}
