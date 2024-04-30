using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria009_Media
{
    public class Audio : Media, IPlayable, IHasVolume
    {
        public Audio(string titolo)
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
        public override void Execute()
        {
            Play();
        }

        public void Play()
        {
            for (int i = 0; i < Volume; i++)
                Console.WriteLine(Titolo);
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
