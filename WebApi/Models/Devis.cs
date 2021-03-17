using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    public class Devis
    {
        public int DevisId { get; set; }
        [ForeignKey("WholesalerDevisId")]
        public Wholesaler WholesalerDevis { get; set; }
        public int WholesalerDevisId { get; set; }
        public string WholesalerDevisName { get; set; }
        public double StockDevis { get; set; }

        public double PriceDevis { get; set; }
        [ForeignKey("BeerDevisId")]
        public Beer BeerDevis { get; set; }
        [IgnoreDataMember]
        public int BeerDevisId { get; set; }
        public string BeerDevisName { get; set; }

        public string NameCustomer { get; set; }
        public string PhoneCustomer { get; set; }
    }
}
