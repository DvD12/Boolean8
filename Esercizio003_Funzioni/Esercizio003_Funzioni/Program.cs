namespace Esercizio003_Funzioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void StampaArray(int[] array)
            {
                Console.Write("[");
                int i = 0;
                foreach (int elem in array)
                {
                    Console.Write(elem);
                    if (i < array.Length - 1)
                        Console.Write(", ");
                    i++;
                }
                Console.Write("]");
            }
            string ArrayToString(int[] array)
            {
                string result = "[";
                int i = 0;
                foreach (int elem in array)
                {
                    result += elem;
                    if (i < array.Length - 1)
                        result += ", ";
                    i++;
                }
                result += "]";
                return result;
            }

            int Quadrato(int numero)
            {
                return numero * numero;
            }

            int[] CopiaArray(int[] array)
            {
                int[] copia = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                    copia[i] = array[i];
                return copia;
            }
            int[] ElevaArrayAlQuadrato(int[] array)
            {
                int[] copia = CopiaArray(array);
                for (int i = 0; i < copia.Length; i++)
                {
                    copia[i] = Quadrato(copia[i]);
                }
                return copia;
            }
            int SommaElementiArray(int[] array)
            {
                int somma = 0;
                foreach (int elem in array)
                    somma += elem;
                return somma;
            }

            int[] array = { 1, 2, 3, 4 };
            Console.WriteLine($"L'array è {ArrayToString(array)}");
            int n1 = Quadrato(10);
            Console.WriteLine($"n1 è {n1}");
            int[] array2 = ElevaArrayAlQuadrato(array);
            Console.WriteLine($"L'array è {ArrayToString(array)}");
            Console.WriteLine($"L'array2 è {ArrayToString(array2)}");
            int somma = SommaElementiArray(array);
            Console.WriteLine($"La somma di {ArrayToString(array)} è {somma}");
        }
    }
}
