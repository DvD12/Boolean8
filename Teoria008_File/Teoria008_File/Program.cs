using Newtonsoft.Json;

namespace Teoria008_File
{
    public class CustomException : Exception
    {
        public override string Message => "My custom exception";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //LeggiDaJson();
            string path = "C:\\temp\\LibriPreferiti.txt";
            string path2 = "C:\\temp\\LibriPreferiti2.txt";
            var libri = LeggiDaTesto(path);
            foreach (var libro in libri)
                Console.WriteLine(libro.ToString());
            //ScriviInTesto(libri, path2);
        }

        public static void LeggiDaJson()
        {
            // 1. Determiniamo la fonte dei miei dati
            string path = "C:\\temp\\LibriJson.txt";
            var text = File.ReadAllText(path);

            // 2. Trasformiamo i dati stringa in oggetti
            // Prendo una stringa e la interpreto
            // come un oggetto JSON rappresentante una List<Libro>
            // invocando il costruttore vuoto di List<Libro>
            var libri = JsonConvert.DeserializeObject<List<Libro>>(text);

            // Prendo un oggetto e la serializzo come stringa in formato JSON
            var nuovoTesto = JsonConvert.SerializeObject(libri);
        }

        public static List<Libro> LeggiDaTesto(string path)
        {
            List<Libro> libriPreferiti = new List<Libro>();
            //var text = File.ReadAllText(path);
            var stream = File.OpenText(path);
            
            int i = 0;
            while (stream.EndOfStream == false) // equivale a dire che la posizione dello stream è MINORE della lunghezza dei bytes dello stream
            {
                //Console.WriteLine($"Sono in posizione {stream.BaseStream.Position}/{stream.BaseStream.Length}");
                var linea = stream.ReadLine();
                //Console.WriteLine(linea);

                i++;
                if (i <= 2) // Ignoro le prime due righe del testo
                    continue;

                // Converto ogni linea in un libro
                string titolo = "N/A";
                string autore = "N/A";
                int anno = 0;
                try
                {
                    var dati = linea.Split(',');
                    anno = int.Parse(dati[2]);
                    titolo = dati[0];
                    autore = dati[1];
                    if (dati.Length > 3)
                        throw new Exception("Ci sono più di 3 campi (Titolo, Autore, Anno)");

                    List<int> campiVuoti = new();
                    for (int j = 0; j < dati.Length; j++)
                        if (string.IsNullOrWhiteSpace(dati[j]))
                            campiVuoti.Add(j);

                    if (campiVuoti.Count > 0)
                    {
                        string indici = "";
                        foreach (var indice in campiVuoti)
                            indici += $"{indice + 1}, ";
                        throw new Exception($"I campi nelle posizioni {indici} non possono essere vuoti");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Libro l = new Libro(titolo, autore, anno);
                    libriPreferiti.Add(l);
                }
            }

            stream.Dispose();
            return libriPreferiti;
        }

        public static void ScriviInTesto(List<Libro> libri, string path)
        {
            using StreamWriter stream = File.CreateText(path); // using può essere usato solo quando si hanno delle classi che implementano IDisposable
            foreach (var libro in libri)
                stream.WriteLine(libro.ToString());
            //stream.Dispose(); // è implicito nello using
        }
    }
}
