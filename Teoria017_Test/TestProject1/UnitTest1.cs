using Teoria017_Test;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InsertSuccess()
        {
            Gestionale.InsertPersona("Pippo", 95);
            //var pippo = Gestionale.Persone.FirstOrDefault(x => x.Nome == "Pippo");
            //Assert.IsTrue(pippo != null);
            var pippoExists = Gestionale.Persone.Any(x => x.Nome == "Pippo");
            Assert.IsTrue(pippoExists);
        }

        [Test]
        public void InsertPersonaInvalidName()
        {
            bool exceptionRaised = false;
            try
            {
                Gestionale.InsertPersona("", 95);
            }
            catch (Exception e)
            {
                exceptionRaised = true;
            }
            Assert.IsTrue(exceptionRaised == true, "Ci aspettavamo che InsertPersona generasse un'eccezione, invece è andata bene");
        }

        // Richiamare il metodo di filtro
        //    public static List<Persona> GetPersoneByName(string name)
        // e verificare che i dati restituiti (filtrati) siano quelli previsti
        [Test]
        [TestCase("Pippo")]
        [TestCase("")]
        public void TestGetPersonByName(string name)
        {
            Gestionale.Persone.Add(new Persona(name, 55));
            var filtrata = Gestionale.GetPersoneByName(name); // TEST!
            var exists = filtrata.Any(x => x.Nome == name);
            Assert.IsTrue(exists == true);
        }
    }
}