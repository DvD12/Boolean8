using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria008_Eccezioni
{
    public class BottigliaVuotaException : Exception
    {
    }

    public class Bottiglia
    {
        public int Litri { get; set; }

        public Bottiglia(int litri)
        {
            this.Litri = litri;
        }

        public void Bevi(int litri)
        {
            if (litri > this.Litri)
                throw new BottigliaVuotaException();

            Console.WriteLine($"Glu glu, ho bevuto {litri} litri");
            this.Litri -= litri;
        }
    }
}
