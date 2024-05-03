namespace OOP_Recap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                Console.WriteLine("Fornisci il titolo del programma eventi");
                string programmaTitolo = Console.ReadLine();
                ProgrammaEventi programma = new ProgrammaEventi(programmaTitolo);

                int numEventi = GetFromInput("Inserisci numero di eventi");
                while (programma.GetEventsCount() < numEventi)
                {
                    try
                    {
                        var evento = CreateEvent();
                        programma.AddEvento(evento);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine($"Numero eventi {programma.GetEventsCount()}");
                Console.WriteLine(programma.GetTitoloAndEventiText());

                var data = GetDateFromInput("Inserisci data in cui cercare eventi");
                var eventsInDate = programma.GetEventsInDate(data);
                Console.WriteLine(ProgrammaEventi.GetEventsText(eventsInDate));

                programma.ClearEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Evento CreateEvent()
        {
            Console.WriteLine("Inserisci titolo evento");
            string titolo = Console.ReadLine();
            Evento e = new Evento();
            e.Titolo = titolo;
            DateTime data = GetDateFromInput("Inserisci data evento");

            int numPosti = GetFromInput("Inserisci numero posti totali");

            Evento evento = new Evento(titolo, data, numPosti);

            int numPrenotaioni = GetFromInput("Quante prenotazioni vuoi effettuare?");
            evento.PrenotaPosti(numPrenotaioni);

            Console.WriteLine(evento.GetPostiPrenotatiText());

            string input = "";
            while (input != "no")
            {
                Console.WriteLine("Vuoi disdire posti? (sì/no)");
                input = Console.ReadLine();
                if (input == "sì")
                {
                    int numDaDisdire = GetFromInput("Quanti posti?");
                    evento.DisdiciPosti(numDaDisdire);
                    Console.WriteLine(evento.GetPostiPrenotatiText());
                }
            }

            return evento;
        }

        private static int GetFromInput(string displayText)
        {
            string resultText = "";
            int result = default;
            while (int.TryParse(resultText, out result) == false)
            {
                Console.WriteLine(displayText);
                resultText = Console.ReadLine();
            }

            return result;
        }
        private static DateTime GetDateFromInput(string displayText)
        {
            string dataTesto = "";
            DateTime data = default;
            while (DateTime.TryParse(dataTesto, out data) == false)
            {
                Console.WriteLine(displayText);
                dataTesto = Console.ReadLine();
            }

            return data;
        }
    }
}
