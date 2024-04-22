using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prodotti.IMieiProdotti.Esempio
{
    internal class Prodotto
    {
        public int Codice { get; private set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; } // IVA esclusa
        public int Iva { get; set; } // Percentuale (0-100%)

        public Prodotto(
            string nome, string descrizione,
            decimal prezzo, int iva = 22
            )
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Iva = iva;
            System.Random random = new System.Random();
            this.Codice = random.Next(0, 1000000);
        }

        //public decimal GetPrezzoBase() => Prezzo;

        public decimal GetPrezzoConIva() // Prezzo * (1 + Iva)
            => Prezzo * (1 + (decimal)Iva / 100);

        public string GetNomeEsteso() => $"{GetCodicePadLeft()}_{Nome}";

        public string GetCodicePadLeft()
            => Codice.ToString().PadLeft(8, '0');

        public string GetFullDescription()
        {
            string desc = "=================================";
            desc += $"PRODOTTO {GetNomeEsteso()}{Environment.NewLine}";
            desc += $"- Descrizione {this.Descrizione}{Environment.NewLine}";
            desc += $"- Prezzo base {this.Prezzo:F2}{Environment.NewLine}";
            desc += $"- IVA {this.Iva}%{Environment.NewLine}";
            desc += $"- Prezzo {this.GetPrezzoConIva():F2}{Environment.NewLine}";
            return desc;
        }
    }
}
