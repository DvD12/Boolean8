using Esercizio016_EF;

namespace Esercizio016_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Initializzo DB...
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, -10, 0)]
        [TestCase(1000000000, -2000000000, -1000000000)]
        public void TestSomma(int x, int y, int expectedResult)
        {
            int somma = Calcolatrice.Somma(x, y); // valore da testare
            Assert.IsTrue(somma == expectedResult, $"Expected: {expectedResult}, actual: {somma}");
        }

        /*public void TestAggiuntaStudente()
        {
            // Chiamo la funzione
            // Chiamo il DB e verifico che la funzione abbia prodotto l'effetto voluto
            InsertVideogame(); // "pippo 3"
            Assert.IsTrue(DB.Videogames.Where(x => x.Name == "pippo 3") != null);
        }*/
    }
}