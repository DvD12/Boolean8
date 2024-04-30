using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria009_Media
{
    public interface IPlayable
    {
        public void Play();
    }
    public interface IHasVolume
    {
        public void Weaker();
        public void Louder();
        public void PrintVolume();
    }
    public interface IHasBrightness
    {
        public void Brighter();
        public void Darker();
        public void PrintBrightness();
    }
    public abstract class Media
    {
        public string Titolo { get; set; }
        public abstract void Execute();
    }
}
