using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria005_OOP2
{
    public class Immobile
    {
        public string Codice { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public string Città { get; set; }
        public int SuperficieMq { get; set; }

        public int NumeroPersoneInteressate { get; private set; }

        public void IncrementaNumeroPersoneInteressate() => NumeroPersoneInteressate++;

        public virtual void StampaInfo()
        {
            Console.WriteLine(Codice);
        }

        public void ReimpostaSuperficie(int mq)
        {
            SuperficieMq = mq;
        }
    }

    public class Box : Immobile
    {
        public int PostiAuto { get; set; }

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine(PostiAuto);
        }
    }
    public class Abitazione : Immobile
    {
        public int NumeroVani { get; set; }
        public int NumeroBagni { get; set; }
        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine(NumeroVani);
        }
    }
    public class Villa : Abitazione
    {
        public int DimensioneGiardinoMq { get; set; }
        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine(DimensioneGiardinoMq);
        }

        public void ReimpostaSuperficie(int superficie, int giardino)
        {
            base.ReimpostaSuperficie(superficie);
            DimensioneGiardinoMq = giardino;
        }
    }
}
