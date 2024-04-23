using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio005_Biblioteca
{
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome}";
        }
    }
    public class Utente : Persona
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }

        public Utente(string nome, string cognome,
            string email, string password, string telefono)
            : base(nome, cognome)
        {
            Email = email;
            Password = password;
            Telefono = telefono;
        }
    }
    public class Autore : Persona
    {
        public Autore(string nome, string cognome)
            : base(nome, cognome)
        {

        }
    }
}
