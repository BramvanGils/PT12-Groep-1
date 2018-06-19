using NeverBoardSoftwareApplicatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeverBoardSoftwareApplicatie
{
    public class SchaakSpel
    {
        public enum Type { Pion, Toren, Paard, Loper, Konigin, Koning};
        public enum Kleur { Zwart, Wit};
        private enum Status {Leeg, Lopen, Slaan};

        public List<SchaakStuk> Bord = new List<SchaakStuk>();
        public List<Point> SlaanLocaties = new List<Point>();
        public List<Point> LoopLocaties = new List<Point>();
        public Point GeselecteerdeLocatie = new Point(2,2);
        public readonly bool speler1Wit;
        public Kleur HuidigeSpeler = Kleur.Wit;

        public SchaakSpel(bool Speler1Wit)
        {
            speler1Wit = Speler1Wit;
            BereidBordVoor();
            VindLocaties(GeselecteerdeLocatie);
        }

        public void UpdateBord()
        {

        }

        private void BereidBordVoor()
        {
            //plaats pionen
            for (int x = 1; x < 9; x ++)
            {
                for (int y = 2; y < 8; y += 5)
                {
                    Bord.Add(new SchaakStuk(Type.Pion,(Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(x,y)));
                }
            }

            //plaats torens
            for (int x = 1; x < 9; x += 7)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Toren, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(x, y)));
                }
            }

            //plaats paarden
            for (int x = 2; x < 8; x += 5)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Paard, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(x, y)));
                }
            }

            //plaats lopers
            for (int x = 3; x < 7; x += 3)
            {
                for (int y = 1; y < 9; y += 7)
                {
                    Bord.Add(new SchaakStuk(Type.Loper, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(x, y)));
                }
            }
            
            //plaats koniginen
            for (int y = 1; y < 9; y += 7)
            {
                Bord.Add(new SchaakStuk(Type.Konigin, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(4, y)));
            }

            //plaats koningen
            for (int y = 1; y < 9; y += 7)
            {
                Bord.Add(new SchaakStuk(Type.Koning, (Kleur)Convert.ToInt32(speler1Wit != (y > 4)), new Point(5, y)));
            }
        }

        public void VindLocaties(Point Locatie)
        {   
            foreach (SchaakStuk Stuk in Bord)
            {
                if (Locatie == Stuk.locatie && HuidigeSpeler == Stuk.kleur)
                {
                    SlaanLocaties.Clear();
                    LoopLocaties.Clear();
                    switch (Stuk.type)
                    {
                        case Type.Pion:
                            if (Stuk.kleur == Kleur.Zwart)
                            {
                                CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y - 1));
                                if (!Stuk.HeeftBewogen)
                                {
                                    CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y - 2));
                                }
                                break;
                            }
                            else
                            {
                                CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + 1));
                                if (!Stuk.HeeftBewogen)
                                {
                                    CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + 2));
                                }
                                break;
                            }/*
                        case Type.Toren:
                            for(int x = -1; x < 3; x++)
                            {
                                for(int y = )
                            }
                            break;*/
                        case Type.Paard:

                            break;
                        case Type.Loper:

                            break;
                        case Type.Konigin:

                            break;
                        case Type.Koning:

                            break;
                    }
                }
            }
        }

        private void CheckLocatie(Point locatie)
        {
            foreach (SchaakStuk AnderStuk in Bord)
            {
                if (AnderStuk.locatie == locatie)
                {
                    if (AnderStuk.kleur != HuidigeSpeler)
                    {
                        SlaanLocaties.Add(locatie);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            LoopLocaties.Add(locatie);
        }
    }
}
