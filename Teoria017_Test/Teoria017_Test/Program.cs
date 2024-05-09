namespace Teoria017_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Dictionary<bool, List<string>> alunni = new();
            alunni[true] = new()
            {
                "Alessandro Fontana",
                "Anatoliy Zakhryapin",
                "Andrea Manigrasso",
                "Argel Dela Cruz",
                "Calin Cretu",
                "Cristopher Ferrari",
                "Davide Corleto",
                "Dorin Vieru",
                "Enrico Foresta",
                "Federico Maiocchi",
                "Francesco Rapetti",
                "Gabriele Palma",
                "Giorgio Belardelli",
                "Luigi Tarallo",
                "Massimiliano Gilli",
                "Mirko Markasco",
                "Samuele Benato",
                "Oder Risi",
                "Paolo Flore",
                "Raoul Bongarzoni",
                "Valerio Bartoletti",
            };
            alunni[false] = new()
            {
                "Marco Picca",
                "Davide Prencipe",
                "Umberto Serino"
            };


            System.Random rng = new Random();
            int i = rng.Next(0, alunni[true].Count);
            string nome = alunni[true][i];
        }
    }
}
