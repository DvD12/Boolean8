namespace Teoria003_Funzioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void StampaVirgolaESpazio()
            {
                Console.Write(", ");
            }
            void StampaArray(int[] array)
            {
                Console.Write("(");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                    if (i < array.Length - 1)
                        StampaVirgolaESpazio();
                }
                Console.Write(")");
            }

            int[] numeri = { 1, 2, 3, 4 };
            StampaArray(numeri);

            int Fattoriale(int numero)
            {
                int risultato = 1;
                for (int i = 1; i <= numero; i++)
                    risultato *= i;
                return risultato;
            }

            int FattorialeRicorsivo(int numero)
            {
                if (numero <= 1)
                    return numero;
                return numero * FattorialeRicorsivo(numero - 1);
            }

            var risultato = FattorialeRicorsivo(3);

            {
                int IncrementaNumero(int num)
                {
                    num = num + 1;
                    return num;
                }

                int x = 3;
                IncrementaNumero(x);
                // Quanto vale x ora?
            }

            {
                int IncrementaNumero(ref int num)
                {
                    num = num + 1;
                    return num;
                }

                int x = 3;
                IncrementaNumero(ref x);
                // Quanto vale x ora?
            }

            {
                void ModificaArray(int[] num)
                {
                    for (int i = 0; i < num.Length; i++)
                        num[i] = num[i] + 1;
                }

                int[] array = { 1, 2, 3 };
                ModificaArray(array);
            }

            {
                int[] ClonaArray(int[] numeri)
                {
                    int[] nuovoArray = new int[numeri.Length];
                    for (int i = 0; i < numeri.Length; i++)
                        nuovoArray[i] = numeri[i];

                    return nuovoArray;
                }

                int[] array = { 1, 2, 3 };
                int[] array2 = array;
                int[] array3 = ClonaArray(array2);
                array[1] = 5;
                // Cosa contengono array, array2, array3?
            }

            int contatore = 0;

            {
                int numero = int.Parse("3");
                var result = int.TryParse("5", out numero);
            }

            {
                bool TentaConversione(string input, out int numero)
                {
                    contatore++;
                    if (input == "1")
                    {
                        numero = 1;
                        return true;
                    }
                    numero = 100;
                    return false;
                }
                //int num;
                var result = TentaConversione("1", out int num); // se 114 fosse decommentata, dovrei scrivere solo "out num"
                Console.WriteLine(num);
                var result2 = TentaConversione("123891823", out num);
                //var result3 = TentaConversione("123", out numero); // errore
            }

            /*
             * Snack 11
                    Dare la possibilità di inserire due parole.
                    Verificare tramite una funzione che le due parole abbiano la stessa lunghezza.
                    Se hanno la stessa lunghezza, stamparle entrambe, altrimenti stampare la più lunga delle due.
                Snack 12
                    Scrivere una funzione per verificare se un numero è pari o dispari.
                    Quindi chiedere un numero all'utente e comunicargli se è pari o dispari.
            */
            {
                string parola1, parola2;
                Console.WriteLine("Inserisci parola 1");
                parola1 = Console.ReadLine();
                Console.WriteLine("Inserisci parola 2");
                parola2 = Console.ReadLine();

                void ParagonaParole(string uno, string due)
                {
                    if (uno.Length == due.Length)
                        Console.WriteLine($"{uno} {due}");
                    else if (uno.Length > due.Length)
                        Console.WriteLine(uno);
                    else
                        Console.WriteLine(due);
                }

                ParagonaParole(parola1, parola2);
            }
            {
                void PariODispari(int num)
                {
                    if (num % 2 == 0)
                        Console.WriteLine("Il numero è pari");
                    else
                        Console.WriteLine("Il numero è dispari");
                }

                int numero;
                Console.WriteLine("Inserisci numero");
                while (int.TryParse(Console.ReadLine(), out numero) == false)
                {
                    Console.WriteLine("Sintassi errata. Inserisci numero");
                }
                PariODispari(numero);
            }
        }
    }
}
