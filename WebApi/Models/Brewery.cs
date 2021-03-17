using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }

        [Required]
        public string BreweryName { get; set; }

        [IgnoreDataMember]
        public IList<Beer> BBeersList { get; set; }
    }
}
