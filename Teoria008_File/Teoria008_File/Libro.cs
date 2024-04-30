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

        public Libro(string titolo, string autore, int anno = 1900)
        {
            this.Titolo = titolo;
            this.Autore = autore;
            try
            {
                if (anno < 1900)
                    throw new Exception("L'anno deve essere maggiore di 1900");
                this.Anno = anno;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            return $"{Titolo}, {Autore} ({Anno})";
        }
    }
}
