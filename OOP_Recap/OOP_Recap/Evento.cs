using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Recap
{
    public class Evento
    {
        private string _Titolo;
        public string Titolo
        {
            get => _Titolo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Il titolo non può essere vuoto");
                _Titolo = value;
            }
        }
        private DateTime _Data;
        public DateTime Data
        {
            get => _Data; // equivale a { return _Data; }
            set
            {
                if (value < DateTime.Today)
                    throw new Exception($"La data deve essere almeno {DateTime.Today}");
                _Data = value;
            }
        }
        private int _CapienzaMassima;
        public int CapienzaMassima
        {
            get => _CapienzaMassima;
            private set
            {
                if (value <= 0)
                    throw new Exception($"La capienza massima dev'essere maggiore di zero");
                _CapienzaMassima = value;
            }
        }
        public int NumeroPostiPrenotati { get; private set; } = 0;

        public Evento() { }
        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            this.Titolo = titolo;
            this.Data = data;
            this.CapienzaMassima = capienzaMassima;
        }

        public void PrenotaPosti(int postiDaPrenotare)
        {
            if (DateTime.Today > this.Data)
                throw new Exception("L'evento è già passato");
            if (this.NumeroPostiPrenotati + postiDaPrenotare > this.CapienzaMassima)
                throw new Exception("Non ci sono abbastanza posti");

            this.NumeroPostiPrenotati += postiDaPrenotare;
        }

        public void DisdiciPosti(int postiDaDisdire)
        {
            if (DateTime.Today > this.Data)
                throw new Exception("L'evento è già passato");
            if (postiDaDisdire > this.NumeroPostiPrenotati)
                throw new Exception("Non ci sono abbastanza posti da disdire");

            this.NumeroPostiPrenotati -= postiDaDisdire;
        }

        public override string ToString()
        {
            return $"{this.Data.ToString("dd/MM/yyyy")} - {Titolo}";
        }

        public string GetPostiPrenotatiText()
            => $"Posti {NumeroPostiPrenotati}/{CapienzaMassima}";
    }
}
