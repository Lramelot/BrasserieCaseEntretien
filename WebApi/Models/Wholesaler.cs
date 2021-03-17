using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Wholesaler
    {
        public int WholesalerId { get; set; }

        [Required]
        public string WholesalerName { get; set; }

        [IgnoreDataMember]
        public IList<Beer> WBeersList { get; set; }

        [IgnoreDataMember]
        public int Stock => WBeersList.Count;
    }
}
