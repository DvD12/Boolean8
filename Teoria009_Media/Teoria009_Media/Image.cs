using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria009_Media
{
    public class Image : Media, IHasBrightness
    {
        public Image(string titolo)
        {
            this.Titolo = titolo;
        }

        private double _Brightness = 0.5;
        public double Brightness
        {
            get => _Brightness;
            set
            {
                value = Math.Clamp(value, 0.0, 0.9);
                _Brightness = value;
            }
        }
        public void Brighter()
        {
            Brightness += 0.1;
        }

        public void Darker()
        {
            Brightness -= 0.1;
        }

        public void PrintBrightness()
        {
            Console.WriteLine(Brightness);
        }

        public override void Execute()
        {
            Show();
        }

        public void Show()
        {
            string result = Titolo;
            for (int i = 0; i < Math.Floor(Brightness * 10); i++)
                result += "*";
            Console.WriteLine(result);
        }
    }
}
