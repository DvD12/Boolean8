using System.Numerics;

namespace Esercizio005_Biblioteca
{
    internal class Program
    {
        public static T Somma<T>(T n1, T n2) where T : INumber<T>
        {
            return n1 + n2;
        }

        static void Main(string[] args)
        {
            Biblioteca b = new Biblioteca();
            string input = "";
            while (input != "esci")
            {
                Console.WriteLine("Scegli un'opzione");
                Console.WriteLine("1. Aggiungi documento");
                Console.WriteLine("2. Aggiungi utente");
                Console.WriteLine("3. Aggiungi prestito");
                Console.WriteLine("4. Ricerca documento per codice");
                Console.WriteLine("5. Ricerca documento per titolo");
                Console.WriteLine("6. Ricerca utente per nome e cognome");
                Console.WriteLine("7. Ricerca prestito per nome e cognome");

                input = Console.ReadLine();
                if (input == "1") // Aggiungi documento
                {
                    Console.WriteLine("Inserisci codice");
                    var cod = Console.ReadLine();
                    Console.WriteLine("Inserisci titolo");
                    var titolo = Console.ReadLine();
                    Console.WriteLine("Inserisci anno");
                    var anno = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci uno fra i seguenti settori possibili");

                    foreach (SettoreDocumento s in Enum.GetValues(typeof(SettoreDocumento)))
                    {
                        Console.WriteLine($"{s}");
                    }
                    // Come converto una stringa a un certo Enum
                    var settoreStringa = Console.ReadLine();
                    SettoreDocumento settore = (SettoreDocumento)Enum.Parse(typeof(SettoreDocumento), settoreStringa);

                    Console.WriteLine("Inserisci scaffale");
                    var scaffale = Console.ReadLine();

                    Console.WriteLine("Inserisci nome autore");
                    var nomeAutore = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome autore");
                    var cognomeAutore = Console.ReadLine();
                    var autore = new Autore(nomeAutore, cognomeAutore);

                    var choice = "";
                    Documento documento = null;
                    while (choice != "l" && choice != "d")
                    {
                        Console.WriteLine("Scrivi 'l' per aggiungere un libro, 'd' per aggiungere un DVD");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "l":
                                Console.WriteLine("Inserisci numero pagine");
                                var numPagine = int.Parse(Console.ReadLine());
                                documento = new Libro(cod, titolo, anno, settore, scaffale, autore, numPagine);
                                break;
                            case "d":
                                Console.WriteLine("Inserisci durata");
                                var durata = int.Parse(Console.ReadLine());
                                documento = new DVD(cod, titolo, anno, settore, scaffale, autore, durata);
                                break;
                        }
                    }

                    //var documento = new Documento(cod, titolo, anno, settore, scaffale, autore);
                    b.AggiungiDocumento(documento);
                }
                else if (input == "2") // Aggiungi utente
                {
                    Console.WriteLine("Inserisci nome utente");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome utente");
                    var cognome = Console.ReadLine();
                    Console.WriteLine("Inserisci email");
                    var email = Console.ReadLine();
                    Console.WriteLine("Inserisci password");
                    var psw = Console.ReadLine();
                    Console.WriteLine("Inserisci telefono");
                    var tel = Console.ReadLine();
                    var utente = new Utente(nome, cognome, email, psw, tel);
                    b.AggiungiUtente(utente);
                }
                else if (input == "3") // Aggiungi prestito
                {
                    Console.WriteLine("Inserisci nome utente");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome utente");
                    var cognome = Console.ReadLine();
                    var utente = b.RicercaUtente(nome, cognome);
                    if (utente == null)
                    {
                        Console.WriteLine("Utente non trovato");
                    }
                    else
                    {
                        Console.WriteLine("Inserisci codice documento");
                        var codice = Console.ReadLine();
                        var doc = b.RicercaDocumentoPerCodice(codice);
                        if (doc == null)
                        {
                            Console.WriteLine("Documento non trovato");
                        }
                        else
                        {
                            Console.WriteLine("Inserisci numero di giorni del prestito");
                            int numeroGiorni = int.Parse(Console.ReadLine());
                            DateTime da = DateTime.Now; // DateTime è uno struct, non è una classe: tipo valore, non riferimento
                            DateTime a = da.AddDays(numeroGiorni);
                            b.AggiungiPrestito(utente, da, a, doc);
                        }
                    }
                }
                else if (input == "4") // Ricerca documento per codice
                {
                    Console.WriteLine("Inserisci codice documento");
                    var codice = Console.ReadLine();
                    var doc = b.RicercaDocumentoPerCodice(codice);
                    Console.WriteLine(doc?.ToString() ?? "Documento non trovato");
                    /* equivalente a
                    if (doc == null)
                        Console.WriteLine("Documento non trovato");
                    else
                        Console.WriteLine(doc.ToString());
                    */
                }
                else if (input == "5") // Ricerca documento per titolo
                {
                    Console.WriteLine("Inserisci titolo documento");
                    var titolo = Console.ReadLine();
                    var doc = b.RicercaDocumentoPerTitolo(titolo);
                    Console.WriteLine(doc?.ToString() ?? "Documento non trovato");
                }
                else if (input == "6") // Ricerca utente per nome e cognome
                {
                    Console.WriteLine("Inserisci nome utente");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome utente");
                    var cognome = Console.ReadLine();
                    var utente = b.RicercaUtente(nome, cognome);
                    Console.WriteLine(utente?.ToString() ?? "Utente non trovato");
                }
                else if (input == "7") // Ricerca prestito per nome e cognome
                {
                    Console.WriteLine("Inserisci nome utente");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome utente");
                    var cognome = Console.ReadLine();
                    var prestiti = b.RicercaPrestito(nome, cognome);
                    Console.WriteLine($"Trovati {prestiti.Count} prestiti");
                    foreach (var p in prestiti)
                        Console.WriteLine(p.ToString());
                }
            }
        }

        private static void Esempi()
        {
            var a = new Autore("Pinco", "Pallino");
            var d = new Documento("123", "Ciao", 123123, SettoreDocumento.Storia, "1A", a);
            Console.WriteLine($"L'autore di {d.Titolo} è {d.Autore.Nome} {d.Autore.Cognome}");
            var d2 = new Documento(null, null, 0, SettoreDocumento.Storia, null, null);
            Console.WriteLine($"L'autore di {d2.Titolo} è {d2.Autore.Nome} {d2.Autore.Cognome}");
            var biblioteca = new Biblioteca();
            if (biblioteca.Utenti != null)
                foreach (var utente in biblioteca.Utenti)
                {
                    Console.WriteLine(utente?.Nome); // null.Nome
                }
            Libro l = new("123", "123", 123, SettoreDocumento.Scienza, "123", new Autore("123", "123"), 123);
            
            biblioteca.AggiungiDocumento(l);
        }
    }
}
