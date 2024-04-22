using System.Diagnostics;

namespace Teoria005_OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Film f = new Film("Titanic", new List<string>() { "DiCaprio" }, 120);
            Generica<Film, int> a = new Generica<Film, int>();

            Dictionary<string, Immobile> immobili = new Dictionary<string, Immobile>();
            immobili["123"] = new Box();
            immobili["1234"] = new Abitazione();
            immobili["1234"].StampaInfo();
            //immobili["1234"].NumeroVani = 3; // Non posso, perché immobili sa che ha Immobile, non Abitazione
        }

        /*
        public void StampaArray(int[] array)
        {
            foreach (var element in array)
                Console.WriteLine(element);
        }
        public void StampaArray<T>(T[] array)
        {
            foreach (var element in array)
                Console.WriteLine(element);
        }
        */

        static void EsempiCollezioni()
        {
            int[] numeri = { 1, 2, 3 };
            int[] numeri2 = new int[3];
            numeri2[0] = 1;
            numeri2[1] = 2;
            numeri2[2] = 3;

            List<int> list = new List<int>(); // Invoco il costruttore di List
            //list[1] = 5; // errore!
            list.Add(2);
            list.Add(2);
            list.Add(1);
            list.Add(1);
            list.Add(3);
            list.Remove(2); // Rimuovo il primo elemento pari a 2 che trovo (se lo trovo) // [ 0, 0, 0, 0 ] rimane uguale; [ 0, 1, 0, 2 ] -> [ 0, 1, 0 ]
            list.RemoveAt(2); // Rimuovo l'elemento in posizione [2] (potrebbe dare errore) // [ 100, 50, 20, 10 ] -> [ 100, 50, 10 ]

            System.Random rng = new();
            List<int> list2 = new List<int>()
            {
                1, 2, rng.Next(0, 100)
            };
            foreach (var elemento in list2)
                Console.WriteLine(elemento);

            List<string> list3 = new List<string>();

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary[10] = "dieci"; // 10 non è la posizione sequenziale, ma la chiave!
            dictionary[100] = "cento";
            dictionary.Add(50, "cinquanta");
            //dictionary.Add(10, "dieci"); // error -- la chiave 10 esiste già
            dictionary[10] = "DIECI"; // Sovrascrive il valore già esistente mappato alla chiave 10

            Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
            dictionary2["dieci"] = 10;
            dictionary2.Add("cento", 10);
            dictionary2.Remove("cento");

            foreach (var elemento in dictionary) // elemento è KeyValuePair<int, string>
            {
                Console.WriteLine($"La chiave è {elemento.Key} e il valore è {elemento.Value}");
                //elemento.Value = "CIAO"; // errore! è di sola lettura
            }

            foreach (var chiave in dictionary.Keys) // elemento è int
            {
                Console.WriteLine($"La chiave è {chiave} e il valore è {dictionary[chiave]}");
                dictionary[chiave] = "CIAO"; // questo lo posso fare
            }
        }

        static void TestComplessitàComputazionale() // Richiede MOLTA memoria
        {

            // Complessità computazioniale
            // ============================
            Stopwatch s = new Stopwatch();

            // Operazione 1: aggiunta (in coda alla lista) di 100M di elementi
            s.Start();
            List<int> interi = new List<int>();
            for (int i = 0; i < 100000000; i++)
                interi.Add(0);
            s.Stop();
            Console.WriteLine($"100 milioni di interi creati in {s.ElapsedMilliseconds}ms");
            s.Reset();

            // Operazione 2: inserimento (in mezzo) in una specifica posizione // O(1)
            s.Start();
            interi[99999000] = 2;
            s.Stop();
            Console.WriteLine($"Inserimento in posizione 99999000 in {s.ElapsedMilliseconds}ms");
            s.Reset();

            // Operazione 3: Rimozione (in mezzo) di un elemento // O(n)
            s.Start();
            interi.Remove(2);
            s.Stop();
            Console.WriteLine($"Rimozione dell'elemento in posizione 99999000 in {s.ElapsedMilliseconds}ms");
            s.Reset();

            // Operazione 1
            s.Start();
            Dictionary<int, string> dizionarioProva = new Dictionary<int, string>();
            for (int i = 0; i < 100000000; i++)
                dizionarioProva[i] = i.ToString();
            s.Stop();
            Console.WriteLine($"100 milioni di coppie chiave-valore creati in {s.ElapsedMilliseconds}ms");
            s.Reset();

            // Operazione 2: inserimento di una nuova coppia chiave-valore
            s.Start();
            dizionarioProva[1500000000] = "CIAO";
            s.Stop();
            Console.WriteLine($"Inserimento chiave-valore {s.ElapsedMilliseconds}ms");
            s.Reset();

            // Operazione 3: Rimozione di una coppia chiave-valore
            s.Start();
            dizionarioProva.Remove(99999900);
            s.Stop();
            Console.WriteLine($"Rimozione dell'elemento in chiave 99999000 in {s.ElapsedMilliseconds}ms");
        }
    }
}
