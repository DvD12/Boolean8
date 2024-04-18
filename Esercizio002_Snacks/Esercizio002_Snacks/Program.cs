namespace Esercizio002_Snacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SNACK 1
            {
                int a = 0, b = 0;
                Console.WriteLine("Inserisci il primo numero");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci il secondo numero");
                b = Convert.ToInt32(Console.ReadLine());

                // RISOLUZIONE 1
                if (a == b)
                    Console.WriteLine("I due numeri sono uguali");
                else
                {
                    int maggiore = a > b ? a : (b);
                    Console.WriteLine($"Il maggiore è {maggiore}");
                }

                // RISOLUZIONE 2
                string risposta =
                    a == b ? "I due numeri sono uguali"
                           : (a > b ? $"{a} è maggiore"
                                    : $"{b} è maggiore");
                Console.WriteLine(risposta);
            }

            // SNACK 2
            {
                string a, b;
                Console.WriteLine("Inserisci la prima parola");
                a = Console.ReadLine();
                Console.WriteLine("Inserisci la seconda parola");
                b = Console.ReadLine();

                // RISOLUZIONE
                if (a.Length == b.Length)
                    Console.WriteLine("Le due parole hanno la stessa lunghezza");
                else if (a.Length > b.Length)
                    Console.WriteLine($"La parola più lunga è {a}");
                else
                    Console.WriteLine($"La parola più lunga è {b}");
            }

            // SNACK 3
            {
                int quantità = 10;
                int[] numeri = new int[quantità];
                for (int i = 0; i < numeri.Length; i++)
                {
                    Console.WriteLine($"Inserisci il numero in posizione {i + 1}/{numeri.Length}");
                    numeri[i] = Convert.ToInt32(Console.ReadLine());
                }
                int somma = 0;
                foreach (var n in numeri)
                    somma += n;
                Console.WriteLine($"La somma è {somma}");
            }

            // SNACK 4
            {
                int min = 2;
                int max = 10;
                int dimensione = max - min + 1;
                int[] numeri = new int[dimensione];
                for (int i = min; i <= max; i++)
                    numeri[i - min] = i;

                int somma = 0;
                foreach (var n in numeri)
                    somma += n;

                decimal media = (decimal)somma / dimensione;

                Console.WriteLine($"La somma è {somma}");
                Console.WriteLine($"La media è {media}");
            }

            // SNACK 5
            {
                Console.WriteLine("Inserisci un numero");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a % 2 == 0)
                    Console.WriteLine(a);
                else
                    Console.WriteLine(a + 1);
            }

            // SNACK 6
            {
                string[] invitati = { "Pippo", "Costantino", "Giovanbattista" };
                Console.WriteLine("Inserisci il tuo nome");
                string nome = Console.ReadLine();
                bool trovato = false;
                foreach (var invitato in invitati)
                {
                    if (nome == invitato)
                    {
                        trovato = true;
                        break;
                    }
                }
                if (trovato)
                    Console.WriteLine($"Benvenuto, {nome}");
                else
                    Console.WriteLine("Il tuo nome non è nella lista");
            }

            // SNACK 7
            {
                // { 0, 0, 0, 0, 0, 0 }
                // Utente inserisce: 2, 3, 5, 8, 10, 11
                // { 0, 3, 5, 0, 0, 11 } (se uso numeri[i])
                // { 3, 5, 11, 0, 0, 0 } (se uso numeri[j])
                int[] numeri = new int[6];
                int j = 0;
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("Inserisci un numero");
                    int a = Convert.ToInt32(Console.ReadLine());
                    if (a % 2 > 0)
                    {
                        numeri[j] = a;
                        j++;
                    }
                }
            }

            // SNACK 8
            {
                int[] numeri = { 2, 4, 5, 7, 9, 10 };
                int somma = 0;
                for (int i = 0; i < numeri.Length; i++)
                {
                    if (i % 2 == 0)
                        continue;
                    somma += numeri[i];
                }

                /* RISOLUZIONE 2
                for (int i = 1; i < numeri.Length; i += 2)
                    somma += numeri[i];
                */
                
                Console.WriteLine($"La somma dei numeri dispari è {somma}");
            }

            // SNACK 9
            {
                int[] numeri = new int[50];
                int somma = 0;
                for (int i = 0; i < numeri.Length; i++)
                {
                    int numero = 0;
                    while (numero <= 0)
                    {
                        Console.WriteLine("Inserisci un numero > 0");
                        numero = Convert.ToInt32(Console.ReadLine());
                    }
                    numeri[i] = numero;
                    somma += numero;
                    if (somma >= 50)
                        break;
                }
            }

            // SNACK 10
            {
                int numeroArray = Convert.ToInt32(Console.ReadLine());
                Random rng = new Random();
                for (int i = 0; i < numeroArray; i++)
                {
                    int[] numeri = new int[10];
                    for (int j = 0; j < 10; j++)
                        numeri[j] = rng.Next(1, 100 + 1);
                    foreach (int numero in numeri)
                        Console.Write($"{numero} ");
                }
            }
        }
    }
}
