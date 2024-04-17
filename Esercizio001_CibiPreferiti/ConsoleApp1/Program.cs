/*
 * Create un progetto App Console CibiPreferiti con Visual Studio.
Nel programma inizializzate un array con la classifica dei vostri cibi preferiti (minimo 5, massimo 10 elementi).
L’array deve essere già inizializzato nel programma, e i vostri cibi preferiti non vanno chiesti all’utente tramite input.
Una volta dichiarato l’array di cibi preferiti, stampate a video le seguenti informazioni:
- La lunghezza della classifica
- La vostra classifica (dunque stampare l’intero array in ordine indicando la posizione in classifica)
- Il vostro cibo top (prima posizione della classifica)
- Il vostro cibo preferito ma non troppo (ultima posizione della classifica)
BONUS
Stampate a video anche il cibo di mezza classifica, cioè che si trova nella posizione mediana.
Attenzione: gestire anche il caso se aveste una classifica con un numero di elementi pari.
In questo caso vanno stampati i 2 elementi in centro alla vostra classifica.  Buon pomeriggio e buon lavoro!
*/
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {                     //   [0]    [1]    [2]      [3]       [4]      [5] 
            string[] cibiPreferiti = { "uno", "due", "tre", "quattro", "cinque" };

            // 0 1 2 3 4 5 (posizioni)
            // 1 2 3 4 5
            // 1 2 3 4 5 6
            Console.WriteLine($"La lunghezza della classifica è {cibiPreferiti.Length}");

            // METODO 1 di ciclo su array
            for (int i = 0; i < cibiPreferiti.Length; i++)
            {
                Console.WriteLine($"Cibo in posizione {i + 1}: {cibiPreferiti[i]}");
            }

            // METODO 2 di ciclo su array
            /*int posizione = 0;
            foreach (string cibo in cibiPreferiti)
            {
                Console.WriteLine($"Cibo in posizione {posizione + 1}: {cibo}");
                Console.WriteLine(cibo);
                posizione++;
            }*/

            // METODO 3 di ciclo su array
            /*foreach (var elemento in cibiPreferiti.Select((x, i) => (x, i)))
            {
                Console.WriteLine($"Cibo in posizione {elemento.i}: {elemento.x}");
            }*/

            Console.WriteLine($"Cibo in posizione top {cibiPreferiti[0]}");
            Console.WriteLine($"Cibo in posizione ultima {cibiPreferiti[cibiPreferiti.Length - 1]}");

            if (cibiPreferiti.Length % 2 == 1) // dispari
            {
                Console.WriteLine($"Cibo in posizione mediana {cibiPreferiti[cibiPreferiti.Length / 2]}");
            }
            else // pari
            {
                Console.WriteLine($"Cibo in posizione mediana 1 {cibiPreferiti[cibiPreferiti.Length / 2]}");
                Console.WriteLine($"Cibo in posizione mediana 2 {cibiPreferiti[(cibiPreferiti.Length - 1) / 2]}");
            }
        }
    }
}
