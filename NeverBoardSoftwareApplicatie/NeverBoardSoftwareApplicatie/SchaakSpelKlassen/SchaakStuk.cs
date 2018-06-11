using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NeverBoardSoftwareApplicatie.SchaakSpelKlassen;

namespace NeverBoardSoftwareApplicatie
{
    class SchaakStuk
    {
        
        
        public bool HeeftBewogen { get; set; } = false;

        readonly SchaakSpel.Type type;
        readonly SchaakSpel.Kleur kleur;

        public Locatie locatie;
        public SchaakStuk(SchaakSpel.Type Type, SchaakSpel.Kleur Kleur, Locatie Locatie)
        {
            type = Type;
            kleur = Kleur;
            locatie = Locatie;
        }

        public SchaakStuk(SchaakSpel.Type Type, Locatie Locatie)
        {
            type = Type;
            locatie = Locatie;
        }
    }
}
