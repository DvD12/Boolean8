using Esercizio016_EF;

namespace Ciao_Esercizio016_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var softwareHouses = VideogameManager.GetAllSoftwareHouses();
            Console.WriteLine("Seleziona software house");
            foreach (var sh in softwareHouses)
                Console.WriteLine($"{sh.Id}. {sh.Name}");

            int choice = int.Parse(Console.ReadLine());
            //var shChosen = softwareHouses.Where(x => x.Id == choice).FirstOrDefault();
            //var shChosen = softwareHouses.FirstOrDefault(x => x.Id == choice);

            var shChosen = VideogameManager.GetSoftwareHouseById(choice);
            if (shChosen != null)
                foreach (var videogame in shChosen.Videogames)
                    Console.WriteLine($"{videogame.Name}");

            /*foreach (var videogame in shChosen?.Videogames ?? new List<Videogame>())
                Console.WriteLine($"{videogame.Name}");*/
        }
    }
}
