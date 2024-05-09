using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria017_Test
{
    public static class Gestionale
    {
        public static List<Persona> Persone { get; set; } = new List<Persona>();

        public static void InsertPersona(string nome, int età)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Il nome è vuoto");
            if (età < 0)
                throw new Exception("L'età è negativa");

            var p = new Persona(nome, età);
            Persone.Add(p);
        }

        public static List<Persona> GetPersoneByName(string name)
        {
            return Persone.Where(x => x.Nome == name).ToList();
        }
    }
}
