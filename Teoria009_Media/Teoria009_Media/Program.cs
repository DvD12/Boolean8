namespace Teoria009_Media
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Inserisci titolo");
                string titolo = Console.ReadLine();
                Console.WriteLine("a. Inserisci audio");
                Console.WriteLine("v. Inserisci video");
                Console.WriteLine("i. Inserisci immagine");
                string choice = Console.ReadLine();
                Media m = null;
                switch (choice)
                {
                    case "a":
                        m = new Audio(titolo);
                        break;
                    case "v":
                        m = new Video(titolo);
                        break;
                    case "i":
                        m = new Image(titolo);
                        break;
                }
                p.Items[i] = m;
            }

            string mediaChoice = "";
            while (mediaChoice != "0")
            {
                try
                {
                    Console.WriteLine("Inserisci numero da 1 a 5");
                    mediaChoice = Console.ReadLine();
                    int mediaIndex = int.Parse(mediaChoice);
                    p.Execute(mediaIndex - 1);
                }
                catch { }
            }
        }
    }
}
