using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Recap
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            this.Titolo = titolo;
            this.Eventi = new List<Evento>();
        }

        public void AddEvento(Evento evento)
        {
            this.Eventi.Add(evento);
        }

        public List<Evento> GetEventsInDate(DateTime date)
        {
            List<Evento> eventi = new List<Evento>();
            foreach (var evento in Eventi)
                if (evento.Data.Date == date.Date)
                    eventi.Add(evento);

            return eventi;

            //return eventi.Where(x => x.Data.Date == date.Date).ToList();
        }

        public static string GetEventsText(List<Evento> eventi)
        {
            string result = "";
            foreach (var evento in eventi)
                result += $"{evento.ToString()}{Environment.NewLine}";

            return result;
        }

        public int GetEventsCount() => Eventi.Count;

        public void ClearEvents()
        {
            Eventi.Clear();
        }

        public string GetTitoloAndEventiText()
        {
            return $"{this.Titolo}{Environment.NewLine}{GetEventsText(this.Eventi)}";
        }
    }
}
