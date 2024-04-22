using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria005_OOP2
{
    public class Contenuto : Object
    {
        public string Titolo { get; set; }
        public List<string> Attori { get; set; }

        public Contenuto(string titolo, List<string> attori)
        {
            this.Titolo = titolo;
            this.Attori = attori;
        }

        public virtual void Riproduci()
        {
            Console.WriteLine($"Stai guardando {Titolo}");
        }

        public override string ToString()
        {
            return $"Titolo: {Titolo}";
        }
    }
    public class Film : Contenuto
    {
        public string Titolo { get; set; }
        public int Durata { get; set; }

        public Film() : base("Film vuoto", new List<string>())
        {
            
        }
        public Film(string titolo, List<string> attori, int durataInMinuti) : base(titolo, attori)
        {
            this.Durata = durataInMinuti;
        }

        public override void Riproduci()
        {
            Console.WriteLine($"Stai guardando il FILM {Titolo}");
        }
    }
    public class Serie : Contenuto
    {
        public int NumeroEpisodi { get; set; }

        public Serie(string titolo, List<string> attori) : base(titolo, attori)
        {

        }
    }
}
