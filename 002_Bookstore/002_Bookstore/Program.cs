using System.Globalization;

namespace _002_Bookstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titolo;
            string autore;
            string isbn;
            int numeroPagine;
            double peso;
            double larghezza;
            double altezza;
            double profondità;
            double valutazioneMedia;
            int numeroRecensioni;
            bool kindleDisponibile;
            bool copertinaFlessibileDisponibile;

            // ------------
            // INPUT INFO
            // ------------

            Console.WriteLine("Inserisci il titolo");
            titolo = Console.ReadLine();

            Console.WriteLine("Inserisci l'autore");
            autore = Console.ReadLine();

            Console.WriteLine("Inserisci ISBN");
            isbn = Console.ReadLine();

            Console.WriteLine("Inserisci numero pagine");
            numeroPagine = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci il peso in kg");
            peso = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            //peso = float.Parse(Console.ReadLine());
            //peso = Convert.ToDouble(Console.ReadLine().Replace(".", ","), CultureInfo.InvariantCulture);

            Console.WriteLine("Inserisci la larghezza in cm");
            larghezza = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Inserisci l'altezza in cm");
            altezza = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Inserisci la profondità in cm");
            profondità = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Inserisci la valutazione");
            valutazioneMedia = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Inserisci numero recensioni");
            numeroRecensioni = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci disponibilità versione Kindle");
            kindleDisponibile = Convert.ToBoolean(Console.ReadLine()); // l'utente deve scrivere 'true' o 'false'

            // Altro modo di assegnare un bool
            /*
            Console.WriteLine("Inserisci disponibilità Kindle (s/n)");
            var input = Console.ReadLine();
            kindleDisponibile = input == "s";
            // sarebbe equivalente al codice seguente:
            //if (input == "s")
            //    kindleDisponibile = true;
            //else
            //    kindleDisponibile = false;
            */

            Console.WriteLine("Inserisci disponibilità copertina flessibile");
            copertinaFlessibileDisponibile = Convert.ToBoolean(Console.ReadLine());

            // ------------
            // STAMPA INFO
            // ------------

            Console.WriteLine($"Il libro di oggi: {titolo} di {autore}");
            Console.WriteLine("Informazioni generiche");
            Console.WriteLine($"ISBN: {isbn}");
            Console.WriteLine($"Numero pagine: {numeroPagine} pagine");
            Console.WriteLine($"Peso del libro: {peso:F2} kg");
            // equivalente a Console.WriteLine("Peso del libro " + peso.ToString("F2") + " kg");
            Console.WriteLine($"Dimensioni libro: {larghezza} cm X, {altezza} cm Y, {profondità} cm Z");
            Console.WriteLine("Informazioni Amazon:");
            Console.WriteLine($"Numero recensioni: {numeroRecensioni}");
            Console.WriteLine($"Valutazione media: {valutazioneMedia} stelline");
            Console.WriteLine($"Kindle disponibile: {(kindleDisponibile ? "Sì" : "No")}");
            Console.WriteLine($"Copertina flessibile disponibile: {(copertinaFlessibileDisponibile ? "Sì" : "No")}");
        }
    }
}
