using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria008_File
{
    public class Libro
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int Anno { get; set; }

        public Libro(string titolo, string autore, int anno)
        {
            this.Titolo = titolo;
            this.Autore = autore;
            this.Anno = anno;
        }

        public override string ToString()
        {
            return $"{Titolo}, {Autore} ({Anno})";
        }
    }
}
