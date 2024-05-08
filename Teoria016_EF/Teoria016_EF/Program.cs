using Microsoft.EntityFrameworkCore;

namespace Teoria016_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SchoolContext db = new SchoolContext();

            Student student = new Student() // Chiamo il costruttore vuoto
            { // e poi definisco un costruttore "anonimo"
                Name = "New student",
                Email = "a@b.com",
            };
            db.Add(student);
            //db.Students.Where(x => x.Name.EndsWith("Francesco")).ToList(); // Name LIKE '%Francesco'
            db.SaveChanges();

            Student loadedStudent = db.Students.Where(m => m.StudentId == 1)
                .Include(s => s.Reviews)
                .Include(s => s.FrequentedCourses)
                .FirstOrDefault();

            int numeroRecensioni = loadedStudent.Reviews.Count();

            List<int> numeri = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> numeriDispari = FiltraDispari(numeri);
            List<int> numeriPari = FiltraPari(numeri);

            // Funzione anonima
            Func<int, bool> isPari = (x) =>
            {
                return x % 2 == 0;
            };
            Func<int, int, bool, int, int> ritorna5 = (a, b, c, d) =>
            {
                Console.WriteLine(a + b + d);
                return 5;
            };
            var list = numeri.Where(ilMioNumeroGigantesco => ilMioNumeroGigantesco % 2 == 0)
                .Where(x => x > 5);
            List<int> numeriPari2 = Filtra(numeri, isPari);
            List<int> numeriPari3 = Filtra(numeri, x => x % 2 == 0);
        }

        public static List<int> Filtra(List<int> numeri, Func<int, bool> criterio)
        {
            var list = new List<int>();

            foreach (var numero in numeri)
                if (criterio(numero) == true)
                    list.Add(numero);

            return list;
        }
        public static List<int> FiltraDispari(List<int> numeri)
        {
            var list = new List<int>();

            foreach (var numero in numeri)
                if (numero % 2 == 1)
                    list.Add(numero);

            return list;
        }
        public static List<int> FiltraPari(List<int> numeri)
        {
            var list = new List<int>();

            foreach (var numero in numeri)
                if (numero % 2 == 0)
                    list.Add(numero);

            return list;
        }

        public static int? Divisione(int x, int y)
        {
            if (y == 0)
                return null;
            return x / y;
        }
    }
}
