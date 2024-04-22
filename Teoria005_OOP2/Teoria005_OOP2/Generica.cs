using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria005_OOP2
{
    public class Generica<T1, T2> where T1 : Contenuto
    {
        public string Id { get; set; }
        public T1 Valore1 { get; set; }
        public T2 Valore2 { get; set; }
    }
}
