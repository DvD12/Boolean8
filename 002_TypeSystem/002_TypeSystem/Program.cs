namespace _002_TypeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string nome;
                nome = "Ciao";
                char a = 'A';
                Console.WriteLine(a is object == true);
                Console.WriteLine(nome is object == true);
                var numero = 123;

                Console.WriteLine($"Il tipo di {nome} è {nome.GetType()}");
                Console.WriteLine($"Il tipo di {numero} è {numero.GetType()}");
            }
            {
                string nome = "ciao";
                Console.WriteLine(nome);
            }
            {
                float a = 0.582634895628937523f;
                float b = 0.582634895628937523f;
                float c = a - b;
            }
            {
                int a = 5;
                a = 6;
                int b = a;
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
            {
                Console.WriteLine("Immetti un numero");
                var a = Convert.ToInt32(Console.ReadLine());
                int[] numeri = new int[a];
            }
        }

        static void AltraFunzione()
        {
            string nome;
        }
    }
}
