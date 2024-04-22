namespace Teoria004_OOP
{
    public class Rettangolo
    {
        public int Base { get; set; }
        public int Altezza { get; set; }
    }
    public enum Colore // enum è un integer internamente
    {
        Bianco, // potrei scrivere... = 10,
        Rosso,
        Giallo,
        Nero,
        Verde,
        Arancione,
    }
    public class Auto
    {
        public static int NumeroAutoProdotte;

        public Colore Colore;
        // Questa sintassi get; set; è equivalente alla lettura e alla scrittura più generale possibile (vedi Velocità)
        // In questo modo crea automaticamente una backing field "numeroPorte" che non dobbiamo esplicitare
        // MA se esplicitiamo anche uno solo tra get e set DOBBIAMO fare uso di una variabile d'appoggio che non sarebbe più implicita
        public int NumeroPorte { get; set; }
        private int velocità;
        public int Velocità
        {
            get
            {
                return velocità;
            }
            set
            {
                velocità = value;
            }
        }
        private string Targa;
        public Ruota RuotaAnteriore1; // pressione, diametro

        private int numeroRevisioni; // backing field
        public int NumeroRevisioni // Proprietà
        {
            get //get_NumeroRevisioni è la funzione chiamata in lettura
            {
                // potevo ritornare qualunque int, tipo 2039
                return numeroRevisioni;
            }
            // Volendo potrei rendere il set privato: "private set"
            set // internamente è una funzione chiamata "set_NumeroRevisioni" con un particolare parametro chiamato "value"
            {
                numeroRevisioni = value; // value è il valore dato in "input" quando scriverò NumeroRevisioni = 10;
                //NumeroRevisioni = value; // loop infinito! Sto chiamando di nuovo la set di NumeroRevisioni
            }
        }

        public string Rumore => $"Vroom, vado a {velocità}";

        public void Accendi()
        {
            NumeroRevisioni = 5;
            Console.WriteLine(NumeroRevisioni);
            Console.WriteLine($"Sono di colore {Colore} e mi accendo");
        }
        public void Accendi(int velocità)
        {
            // "this" mi può servire per
            // 1) Disambiguare tra attributi/variabili con nomi simili/uguali
            // 2) Avere un'idea veloce di quali siano i riferimenti a proprietà della mia classe rispetto a quelli di variabili
            //    interne alla funzione
            this.Velocità = velocità;
            Console.WriteLine($"Sono di colore {this.Colore} e mi accendo a velocità {Velocità}");
        }

        public void Ripara()
        {
            this.Revisiona(); // Avrei potuto scrivere Officina.Revisiona(this);
            // Qui devo usare "this" se voglio passare alla funzione Officina.Ripara()
            //  l'oggetto stesso che ha chiamato Auto.Ripara()
            Officina.Ripara(this);
        }

        public Auto() // Costruttore
        {
            NumeroAutoProdotte++;
            this.Colore = Colore.Verde;
            NumeroPorte = 100;
            Targa = "asd";
        }
        public Auto(Colore colore, int numeroPorte) : this() // tramite "this()" sto richiamando Auto()
        {
            this.Colore = colore;
            this.NumeroPorte = numeroPorte;
        }
        public Auto(Colore colore, string targa) : this(colore, 4) // tramite "this()" sto richiamando Auto(string, int)
        {
            this.Colore = colore;
            SetTarga(targa);
        }

        public string GetTarga() => this.Targa.Substring(0, 2);
        /* Equivalente a
        {
            return this.Targa.Substring(0, 2);
        }
        */
        public void SetTarga(string targa)
        {
            if (targa.Length < 5)
                Console.WriteLine("La targa non è valida: deve avere più di 5 caratteri");
            else
                this.Targa = targa;
        }

        public static void StampaNumeroAutoProdotte()
        {
            Console.WriteLine(NumeroAutoProdotte);
        }
    }

    public class Ruota
    {
        public int Pressione;
        public int Diametro;
        public Gomma Gomma;
    }
    public class Gomma
    {
        public string Colore { get; set; }
        public string Marca { get; set; }
    }

    public static class Officina // Una classe static deve avere tutto (metodi, attributi) static
    {
        public static Auto Ripara(Auto auto)
        {
            System.Random rng = new Random();
            Console.WriteLine($"L'auto è stata riparata a un costo di {rng.Next(100, 1000)}€");
            return auto;
        }

        public static Auto Revisiona(this Auto auto) // Extension method -- posso richiamare Revisiona come se fosse un metodo di Auto
        {
            System.Random rng = new Random();
            int next = rng.Next(0, 2);
            bool successo = next == 1;
            auto.NumeroRevisioni++;
            Console.WriteLine($"La revisione ha avuto esito {(successo ? "positivo" : "negativo")}");
            return auto;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Auto nuovaAuto = new Auto(Colore.Rosso, 4);
            Auto.StampaNumeroAutoProdotte();
            nuovaAuto.NumeroPorte = 4;
            nuovaAuto.Colore = Colore.Rosso;
            nuovaAuto.Accendi();
            nuovaAuto.Ripara();
            nuovaAuto.Revisiona();
            nuovaAuto.SetTarga("asd");
            
            // nuovaAuto.RuotaAnteriore1.Pressione = 5; // null.Pressione <-- null reference exception
            nuovaAuto.RuotaAnteriore1 = new Ruota();

            Auto nuovaAuto2 = new Auto();
            Auto.StampaNumeroAutoProdotte();
            nuovaAuto2.Colore = Colore.Verde;
            nuovaAuto2.NumeroPorte = 5;
            nuovaAuto2.Accendi();
            
            Auto[] autos = { new Auto(Colore.Giallo, 4), new Auto(Colore.Nero, 2) };
            foreach (var auto in autos)
                auto.Accendi();
        }
    }
}
