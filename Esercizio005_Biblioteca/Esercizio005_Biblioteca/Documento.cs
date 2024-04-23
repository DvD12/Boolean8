using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio005_Biblioteca
{
    public enum SettoreDocumento
    {
        Storia,
        Economia,
        Matematica,
        Scienza,
        Filosofia,
        ProgrammazioneAOggetti,
    }

    public class Documento
    {
        public static int NumeroDocumenti { get; set; }
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }
        public SettoreDocumento Settore { get; set; }
        public string Scaffale { get; set; }
        public Autore Autore { get; set; }

        public Documento(string codice, string titolo, int anno,
            SettoreDocumento settore, string scaffale, Autore autore)
        {
            NumeroDocumenti++;
            Codice = codice;
            Titolo = titolo;
            Anno = anno;
            Settore = settore;
            Scaffale = scaffale;

            //autore ??= new("SCONOSCIUTO", "SCONOSCIUTO");
            // equivalente a vvvvvvvv
            /*
            if (autore == null)
                autore = new("SCONOSCIUTO", "SCONOSCIUTO");
            */

            //Autore = autore; // ATTENZIONE! Così sto passando il riferimento alla variabile autore, il che significa che modificando "autore" dal'esterno potrei modificare anche la proprietà Autore di questa classe
            Autore = new Autore(autore?.Nome ?? "SCONOSCIUTO", autore?.Cognome ?? "SCONOSCIUTO"); // Così faccio una copia e sono sicuro che non verrà modificato accidentalmente
        }

        public override string ToString()
        {
            return $"[{Codice}] '{Titolo}' ({Anno}) -- settore {Settore}, scaffale {Scaffale}";
        }
    }
    public class Libro : Documento
    {
        public int NumeroPagine { get; set; }

        public Libro(string codice, string titolo, int anno,
            SettoreDocumento settore, string scaffale, Autore autore, int numeroPagine)
            : base(codice, titolo, anno, settore, scaffale, autore)
        {
            NumeroPagine = numeroPagine;
        }

        public override string ToString()
        {
            var stringa = base.ToString();
            stringa += $" (num pagine {NumeroPagine})";
            return stringa;
        }
    }
    public class DVD : Documento
    {
        public int Durata { get; set; }

        public DVD(string codice, string titolo, int anno,
            SettoreDocumento settore, string scaffale, Autore autore, int durata)
            : base(codice, titolo, anno, settore, scaffale, autore)
        {
            Durata = durata;
        }

        public override string ToString()
        {
            var stringa = base.ToString();
            stringa += $" (durata {Durata})";
            return stringa;
        }
    }
}
