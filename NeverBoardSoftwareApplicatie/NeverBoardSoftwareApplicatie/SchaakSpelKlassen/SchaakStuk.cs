using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NeverBoardSoftwareApplicatie;

namespace NeverBoardSoftwareApplicatie
{
    public class SchaakStuk
    {
        public bool HeeftBewogen { get; set; } = false;

        public readonly SchaakSpel.Type type;
        public readonly SchaakSpel.Kleur kleur;

        public Point locatie;
        public SchaakStuk(SchaakSpel.Type Type, SchaakSpel.Kleur Kleur, Point Locatie)
        {
            type = Type;
            kleur = Kleur;
            locatie = Locatie;
        }
    }
}
