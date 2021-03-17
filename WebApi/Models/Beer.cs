using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Beer
    {
        [IgnoreDataMember]
        public int BeerId { get; set; }

        [Required]
        public string BeerName { get; set; }

        public double Degree { get; set; }

        [Display(Name = "Prix")]
        public double Price { get; set; }

        [IgnoreDataMember]
        [ForeignKey("BreweryBeerId")]
        public Brewery BreweryBeer { get; set; }

        public int BreweryBeerId { get; set; }

        [IgnoreDataMember]
        public string BreweryBeerName { get; set; }

        [IgnoreDataMember]
        [ForeignKey("WholesalerBeerId")]
        public Wholesaler WholesalerBeer { get; set; }

        public int WholesalerBeerId { get; set; }

        public string WholesalerBeerName { get; set; }

        
    }
}
