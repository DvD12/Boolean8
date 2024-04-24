using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria007_OOPAstrazione
{
    public interface IPoligono
    {
        public decimal CalcolaPerimetro();
        public decimal CalcolaArea();
    }

    public class Rettangolo : IPoligono
    {
        private decimal Base { get; set; }
        public decimal Altezza { get; set; }
        public Rettangolo(decimal b, decimal a)
        {
            this.Base = b;
            this.Altezza = a;
        }
        public decimal CalcolaPerimetro()
        {
            return (Base + Altezza) * 2;
        }
        public decimal CalcolaArea()
        {
            return Base * Altezza;
        }
    }
    public class Triangolo : IPoligono
    {
        private decimal Base { get; set; }
        public decimal Altezza { get; set; }
        public decimal Lato1 { get; set; }
        public decimal Lato2 { get; set; }
        public decimal Lato3 { get; set; }
        public Triangolo(decimal b, decimal a)
        {
            Base = b;
            Altezza = a;
            // TODO deriva i valori di lato1, lato2, lato3
        }
        public Triangolo(decimal l1, decimal l2, decimal l3)
        {
            Lato1 = l1;
            Lato2 = l2;
            Lato3 = l3;
            // TODO deriva i valori di base e altezza
        }
        public decimal CalcolaPerimetro()
        {
            return Lato1 + Lato2 + Lato3;
        }
        public decimal CalcolaArea()
        {
            return Base * Altezza / 2;
        }
    }
}
