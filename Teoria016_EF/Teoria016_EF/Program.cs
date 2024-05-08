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
            db.SaveChanges();
        }

        public static int? Divisione(int x, int y)
        {
            if (y == 0)
                return null;
            return x / y;
        }
    }
}
