using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria009_Media
{
    public class Video : Media, IPlayable, IHasVolume, IHasBrightness
    {
        public Video(string titolo)
        {
            this.Titolo = titolo;
        }

        private int _Volume = 5;
        public int Volume
        {
            get
            {
                return _Volume;
            }
            set
            {
                value = Math.Clamp(value, 0, 10);
                _Volume = value;
            }
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
            Play();
        }

        public void Play()
        {
            string result = "";
            for (int i = 0; i < Volume; i++)
                result += Titolo;
            for (int i = 0; i < Math.Floor(Brightness * 10); i++)
                result += "*";
            Console.WriteLine(result);
        }

        public void PrintVolume()
        {
            Console.WriteLine(Volume);
        }
        public void Louder()
        {
            Volume++;
        }
        public void Weaker()
        {
            Volume--;
        }
    }
}
