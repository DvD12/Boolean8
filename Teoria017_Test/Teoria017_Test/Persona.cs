using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria017_Test
{
    public class Persona
    {
        public string Nome { get; set; }
        public int Età { get; set; }

        public Persona() { }

        public Persona(string nome, int età)
        {
            this.Nome = nome;
            this.Età = età;
        }
    }
}
