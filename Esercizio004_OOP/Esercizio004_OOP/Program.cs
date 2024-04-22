using Prodotti.IMieiProdotti.Esempio;

namespace Esercizio004_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"Argomento: {arg}");
            }

            // int[] numeri = { 1, 2, 3 };
            Prodotti.IMieiProdotti.Esempio.Prodotto[] prodotti =
            {
                new Prodotto("Penna", "BIC", 1.00M),
                new Prodotto("Mouse", "Razer", 15)
            };
            // vvvvvvv Equivale a vvvvvvvv
            //prodotti[0] = new Prodotto("Penna", "BIC", 1.00M);
            //prodotti[1] = new Prodotto("Mouse", "Razer", 15);
            foreach (var prodotto in prodotti)
                Console.WriteLine(prodotto.GetFullDescription());
        }
    }
}
