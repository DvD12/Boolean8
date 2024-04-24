using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria007_OOPAstrazione
{
    public interface IDormiente
    {
        public void Dormi();
    }
    public interface IInteragente
    {
        public void Interagisci();
    }
    public class Auto : IInteragente
    {
        public void Interagisci()
        {
            Console.WriteLine("Vroom");
        }
    }
    public abstract class Animale : IDormiente, IInteragente
    {
        //public abstract int NumeroOcchi { get; set; }
        public void Dormi()
        {
            Console.WriteLine("zzzz");
        }
        public void Interagisci()
        {
            Console.WriteLine("Sto interagendo");
        }
        public abstract void FaiVerso();
    }
    public class Mucca : Animale
    {
        public override void FaiVerso()
        {
            Console.WriteLine("Muuu");
        }
    }
    public class Gatto : Animale
    {
        public override void FaiVerso()
        {
            Console.WriteLine("Miao");
        }
    }
}
