using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio005_Biblioteca
{
    public class Biblioteca
    {
        public Dictionary<string, Documento> Documenti { get; set; } = new();
        public List<Utente> Utenti { get; set; } = new();
        public List<Prestito> Prestiti { get; set; } = new();

        public void AggiungiDocumento(Documento d)
        {
            if (Documenti.ContainsKey(d.Codice) == false) // O(log(n))
                Documenti.Add(d.Codice, d);
        }

        public void AggiungiUtente(Utente utente)
        {
            Utenti.Add(utente);
        }

        public void AggiungiPrestito(Utente utente, DateTime da, DateTime a, Documento d)
        {
            var prestito = new Prestito(d.Codice, utente, da, a);
            Prestiti.Add(prestito);
        }

        public Documento RicercaDocumentoPerCodice(string codice)
        {
            if (Documenti.ContainsKey(codice))
                return Documenti[codice];
            return null;
        }
        public Documento RicercaDocumentoPerTitolo(string titolo)
        {
            foreach (var doc in Documenti.Values)
                if (doc.Titolo == titolo)
                    return doc;

            return null;
        }

        public Utente RicercaUtente(string nome, string cognome)
        {
            foreach (var utente in Utenti)
                if (utente.Nome == nome && utente.Cognome == cognome)
                    return utente;

            return null;
        }

        public List<Prestito> RicercaPrestito(string nome, string cognome)
        {
            List<Prestito> prestiti = new();

            foreach (var prestito in Prestiti)
                if (prestito.UtenteRichiedente?.Nome == nome && prestito.UtenteRichiedente?.Cognome == cognome)
                    prestiti.Add(prestito);

            return prestiti;
        }
    }
}
