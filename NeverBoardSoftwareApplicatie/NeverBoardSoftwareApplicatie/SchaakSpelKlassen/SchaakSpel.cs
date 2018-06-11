using NeverBoardSoftwareApplicatie.SchaakSpelKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBoardSoftwareApplicatie
{
    public class SchaakSpel
    {
        public enum Type { Pion, Toren, Paard, Loper, Konigin, Koning };
        public enum Kleur { Zwart, Wit };

        private List<SchaakStuk> Bord = new List<SchaakStuk>();
        private Kleur HuidigeSpeler = Kleur.Wit;

        public SchaakSpel()
        {

        }

        private void BereidBordVoor()
        {
            //plaats pionen
            for (int x = 1; x < 9; x ++)
            {
                for (int y = 2; y < 9; y += 5)
                    {
                    Bord.Add(new SchaakStuk(Type.Pion, new Locatie(x,y)));
                }
            }

            //plaats torens
            for (int x = 1; x < 9; x += 7)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Toren, new Locatie(x, y)));
                }
            }

            //plaats paarden
            for (int x = 2; x < 8; x += 5)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Pion, new Locatie(x, y)));
                }
            }

            //plaats lopers
            for (int x = 3; x < 7; x += 3)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Pion, new Locatie(x, y)));
                }
            }

            //plaats koniginen
            

            //plaats koningen
        }
    }
}
