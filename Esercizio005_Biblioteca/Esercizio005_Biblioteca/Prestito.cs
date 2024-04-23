using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio005_Biblioteca
{
    public class Prestito
    {
        public string IdDocumentoPresoInPrestito { get; set; }
        public Utente UtenteRichiedente { get; set; }
        public DateTime PrestitoInizio { get; set; }
        public DateTime PrestitoFine { get; set; }

        public Prestito(string idDocumentoPresoInPrestito, Utente u, DateTime prestitoInizio, DateTime prestitoFine)
        {
            IdDocumentoPresoInPrestito = idDocumentoPresoInPrestito;
            UtenteRichiedente = new Utente(u.Nome, u.Cognome, u.Email, u.Password, u.Telefono);
            PrestitoInizio = prestitoInizio;
            PrestitoFine = prestitoFine;
        }

        public override string ToString()
        {
            return $"Codice doc {IdDocumentoPresoInPrestito}> Utente {UtenteRichiedente?.ToString()} -- Da {PrestitoInizio} a {PrestitoFine}";
        }
    }
}
