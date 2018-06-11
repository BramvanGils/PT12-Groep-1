using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBoardSoftwareApplicatie.SchaakSpelKlassen
{
    class Locatie
    {
        public enum PlaatsSituatie { NietPlaatsbaar, Plaatsbaar, Slaanbaar}
        public int x { get; set; }
        public int y { get; set; }
        public PlaatsSituatie situatie {get; set;}

        public Locatie(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public Locatie(int X, int Y, PlaatsSituatie Situatie)
        {
            x = X;
            y = Y;
            situatie = Situatie;
        }
    }
}
