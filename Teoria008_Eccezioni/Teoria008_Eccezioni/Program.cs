namespace Teoria008_Eccezioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bottiglia b = new Bottiglia(10);
                b.Bevi(5);
                b.Bevi(7);
            }
            catch (BottigliaVuotaException e)
            {
                Console.WriteLine("La tua bottiglia non aveva abbastanza liquido");
            }

            try // Tento di eseguire tutte le istruzioni nel blocco try: al primo errore il programma tenta di gestirlo con un blocco catch corrispondente
            {
                int[] numeri = new int[0];
                if (numeri.Length < 1)
                    throw new Exception("Il tuo array ha lunghezza zero");
                Console.WriteLine(numeri[1]); // IndexOutOfRangeException
                Console.WriteLine(numeri[2]);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Errore gestito {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore gestito 2 {e.Message} {e.StackTrace}");
            }
            finally
            {
                Console.WriteLine("Finally!");
            }

            Console.WriteLine("CIAO!");
        }
    }
}
