using System;

namespace WebApi.Models
{
    public class ApiDevisDisplay
    {
        public string Nom_Grossiste { get; set; }
        public string Nom_Biere { get; set; }
        public string Stock { get; set; }
        public string Client_Nom { get; set; }
        public string Client_Telephone { get; set; }
        public string Prix { get; set; }
        public DateTime Date { get; set; }

        public string GetDevis(ApiDevisDisplay apiDevis)
        {
            return
                $"Nom du grossiste : {apiDevis.Nom_Grossiste}{Environment.NewLine}"
                + $"Bière Demandée : {apiDevis.Nom_Biere}{Environment.NewLine}"
                + $"Stock restant: {apiDevis.Stock}{Environment.NewLine}"
                + $"Date : {apiDevis.Date:dd/MM/yyyy}{Environment.NewLine}"
                + $"Nom : {apiDevis.Client_Nom}{Environment.NewLine}"
                + $"Telephone : {apiDevis.Client_Telephone}{Environment.NewLine}"
                + $"Prix de la commande : {apiDevis.Prix}{Environment.NewLine}";
        }
    }
}
