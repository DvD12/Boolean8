using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria009_Media
{
    public class Player
    {
        public Media[] Items { get; set; } = new Media[5];

        public void Execute(int i)
        {
            if (i < 0 || i >= Items.Length)
                throw new Exception("L'elemento non è presente");

            var item = Items[i];
            item.Execute();

            if (item is IHasBrightness b)
            {
                Console.WriteLine("1. incrementa luminosità");
                Console.WriteLine("2. decrementa luminosità");
                Console.WriteLine("3. stampa luminosità");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        b.Brighter();
                        break;
                    case "2":
                        b.Darker();
                        break;
                    case "3":
                        b.PrintBrightness();
                        break;
                }
            }
            if (item is IHasVolume v)
            {
                Console.WriteLine("1. incrementa volume");
                Console.WriteLine("2. decrementa volume");
                Console.WriteLine("3. stampa volume");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        v.Louder();
                        break;
                    case "2":
                        v.Weaker();
                        break;
                    case "3":
                        v.PrintVolume();
                        break;
                }
            }
        }
    }
}
