namespace Teoria007_OOPAstrazione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IInteragente> coseConCuiInteragire = new List<IInteragente>();
            coseConCuiInteragire.Add(new Mucca());
            coseConCuiInteragire.Add(new Auto());
            coseConCuiInteragire.Add(new Gatto());
            foreach (var oggetto in coseConCuiInteragire)
                oggetto.Interagisci();
            /*
            List<Veicolo> veicoli = new List<Veicolo>();
            veicoli.Add(new SportCar());
            veicoli.Add(new UtilityCar());
            foreach (var v in veicoli)
                v.AttivaIlTurbo();
            */

            List<IPoligono> poligoni = new List<IPoligono>();
            poligoni.Add(new Rettangolo(5, 10));
            poligoni.Add(new Triangolo(10, 10));
            foreach (var p in poligoni)
            {
                Console.WriteLine(p.GetType().Name);
                Console.WriteLine(p.CalcolaArea());
            }
        }
    }

    public abstract class Veicolo
    {
        public int VelocitàMassima { get; set; }
        public int NumeroPorte { get; set; }
        public string Nome;
        public void StampaVelocitàMassima()
        {
            Console.WriteLine($"Velocità massima: {VelocitàMassima}");
        }
        public void StampaNumeroPorte()
        {
            Console.WriteLine($"Numero porte {NumeroPorte}");
        }
        public string GetNome()
        {
            return Nome;
        }
        public void Accenditi()
        {
            Console.WriteLine("Mi sto accendendo");
        }
        public void Frena()
        {
            Console.WriteLine("Sto frenando");
        }

        public abstract void AttivaIlTurbo();
        public abstract void TrainaAuto();
    }

    public class SportCar : Veicolo
    {
        public override void AttivaIlTurbo()
        {
            Console.WriteLine("Attivo il turbo");
        }
        public override void TrainaAuto()
        {
            Console.WriteLine("Non posso!");
        }
    }
    public class UtilityCar : Veicolo
    {
        public override void AttivaIlTurbo()
        {
            Console.WriteLine("No se puede");
        }
        public override void TrainaAuto()
        {
            Console.WriteLine("Sto trainando un'auto");
        }
    }
}
