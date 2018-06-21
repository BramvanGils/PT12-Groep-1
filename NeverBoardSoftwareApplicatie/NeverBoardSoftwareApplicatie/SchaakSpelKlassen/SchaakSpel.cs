using NeverBoardSoftwareApplicatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    public class SchaakSpel : PictureBox
    {
        public enum Type { Pion, Toren, Paard, Loper, Konigin, Koning };
        public enum Kleur { Zwart, Wit };

        public List<SchaakStuk> Bord = new List<SchaakStuk>();
        public List<Point> SlaanLocaties = new List<Point>();
        public List<Point> LoopLocaties = new List<Point>();
        public Point GeselecteerdeLocatie = new Point(7, 1);
        public readonly bool speler1Wit;
        public Kleur HuidigeSpeler = Kleur.Wit;

        private Point OudPunt;
        private SchaakStuk RemovedPiece;
        private bool StukheeftBewogen;

        public SchaakSpel(bool Speler1Wit)
        {
            speler1Wit = Speler1Wit;
            BereidBordVoor();
            VindLocaties(GeselecteerdeLocatie);
        }

        private void BereidBordVoor()
        {/*
            //plaats pionen
            for (int x = 1; x < 9; x++)
            {
                for (int y = 2; y < 8; y += 5)
                {
                    Bord.Add(new SchaakStuk(Type.Pion, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(x, y)));
                }
            }*/

            //plaats koniginen
            for (int y = 1; y < 9; y += 7)
            {
                Bord.Add(new SchaakStuk(Type.Konigin, (Kleur)Convert.ToInt32(speler1Wit != (y > 5)), new Point(4, y)));
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

            //plaats koningen
            for (int y = 1; y < 9; y += 7)
            {
                Bord.Add(new SchaakStuk(Type.Koning, (Kleur)Convert.ToInt32(speler1Wit != (y > 4)), new Point(5, y)));
            }
        }

        public void VindLocaties(Point Locatie)
        {
            SlaanLocaties.Clear();
            LoopLocaties.Clear();
            foreach (SchaakStuk Stuk in Bord)
            {
                if (Locatie == Stuk.locatie && HuidigeSpeler == Stuk.kleur)
                {
                    switch (Stuk.type)
                    {
                        case Type.Pion:
                            if (Stuk.kleur == Kleur.Zwart)
                            {
                                if (!CheckLopen(new Point(Stuk.locatie.X, Stuk.locatie.Y - 1)) && !Stuk.HeeftBewogen)
                                {
                                    CheckLopen(new Point(Stuk.locatie.X, Stuk.locatie.Y - 2));
                                }
                            }
                            else
                            {
                                if (!CheckLopen(new Point(Stuk.locatie.X, Stuk.locatie.Y + 1)) && !Stuk.HeeftBewogen)
                                {
                                    CheckLopen(new Point(Stuk.locatie.X, Stuk.locatie.Y + 2));
                                }
                            }

                            if (Stuk.kleur == Kleur.Zwart)
                            {
                                CheckSlaan(new Point(Stuk.locatie.X + 1, Stuk.locatie.Y - 1));
                                CheckSlaan(new Point(Stuk.locatie.X - 1, Stuk.locatie.Y - 1));
                                break;
                            }
                            else
                            {
                                CheckSlaan(new Point(Stuk.locatie.X + 1, Stuk.locatie.Y + 1));
                                CheckSlaan(new Point(Stuk.locatie.X - 1, Stuk.locatie.Y + 1));
                                break;
                            }
                        case Type.Toren:
                            for (int x = -1; x > -8; x--)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + x, Stuk.locatie.Y)))
                                {
                                    x = -8;
                                }
                            }
                            for (int x = 1; x < 8; x++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + x, Stuk.locatie.Y)))
                                {
                                    x = 8;
                                }
                            }
                            for (int y = -1; y > -8; y--)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + y)))
                                {
                                    y = -8;
                                }
                            }
                            for (int y = 1; y < 8; y++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + y)))
                                {
                                    y = 8;
                                }
                            }
                            break;
                        case Type.Paard:
                            for (int x = -1; x < 2; x += 2)
                            {
                                for (int y = -1; y < 2; y += 2)
                                {
                                    CheckLocatie(new Point(Stuk.locatie.X + 2 * x, Stuk.locatie.Y + 1 * y));
                                    CheckLocatie(new Point(Stuk.locatie.X + 1 * x, Stuk.locatie.Y + 2 * y));
                                }
                            }
                            break;
                        case Type.Loper:
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + i, Stuk.locatie.Y + i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X - i, Stuk.locatie.Y + i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + i, Stuk.locatie.Y - i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X - i, Stuk.locatie.Y - i)))
                                {
                                    i = 8;
                                }
                            }
                            break;
                        case Type.Konigin:
                            for (int x = -1; x > -8; x--)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + x, Stuk.locatie.Y)))
                                {
                                    x = -8;
                                }
                            }
                            for (int x = 1; x < 8; x++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + x, Stuk.locatie.Y)))
                                {
                                    x = 8;
                                }
                            }
                            for (int y = -1; y > -8; y--)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + y)))
                                {
                                    y = -8;
                                }
                            }
                            for (int y = 1; y < 8; y++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X, Stuk.locatie.Y + y)))
                                {
                                    y = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + i, Stuk.locatie.Y + i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X - i, Stuk.locatie.Y + i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X + i, Stuk.locatie.Y - i)))
                                {
                                    i = 8;
                                }
                            }
                            for (int i = 1; i < 8; i++)
                            {
                                if (CheckLocatie(new Point(Stuk.locatie.X - i, Stuk.locatie.Y - i)))
                                {
                                    i = 8;
                                }
                            }
                            break;
                        case Type.Koning:
                            for (int x = -1; x < 2; x++)
                            {
                                for (int y = -1; y < 2; y++)
                                {
                                    CheckLocatie(new Point(Stuk.locatie.X + x, Stuk.locatie.Y + y));
                                }
                            }
                            break;
                    }
                }
            }
        }

        private bool CheckLocatie(Point locatie)
        {
            foreach (SchaakStuk AnderStuk in Bord)
            {
                if (locatie.X > 8 || locatie.X < 1 || locatie.Y > 8 || locatie.Y < 1)
                {
                    return true;
                }
                if (AnderStuk.locatie == locatie)
                {
                    if (AnderStuk.kleur != HuidigeSpeler)
                    {
                        SlaanLocaties.Add(locatie);
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            LoopLocaties.Add(locatie);
            return false;
        }

        private bool CheckSlaan(Point locatie)
        {
            foreach (SchaakStuk AnderStuk in Bord)
            {
                if (locatie.X > 8 || locatie.X < 1 || locatie.Y > 8 || locatie.Y < 1)
                {
                    return true;
                }
                if (AnderStuk.locatie == locatie)
                {
                    if (AnderStuk.kleur != HuidigeSpeler)
                    {
                        SlaanLocaties.Add(locatie);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckLopen(Point locatie)
        {
            foreach (SchaakStuk AnderStuk in Bord)
            {
                if (locatie.X > 8 || locatie.X < 1 || locatie.Y > 8 || locatie.Y < 1)
                {
                    return true;
                }
                if (AnderStuk.locatie == locatie)
                {
                    {
                        return true;
                    }
                }
            }
            LoopLocaties.Add(locatie);
            return false;
        }

        public bool VerwerkKlik(Point locatie)
        {
            Rectangle ControleBord;
            if (speler1Wit && HuidigeSpeler == Kleur.Wit || !speler1Wit && HuidigeSpeler == Kleur.Zwart)
            {
                ControleBord = SchaakbordRenderFuncties.controleBord1;
            }
            else
            {
                ControleBord = SchaakbordRenderFuncties.controleBord2;
            }

            if
            (InBox(locatie, ControleBord) && CheckKleur(LocatienaarPunt(locatie, ControleBord)))
            {
                GeselecteerdeLocatie = LocatienaarPunt(locatie, ControleBord);
                VindLocaties(GeselecteerdeLocatie);
            }
            else if (InBox(locatie, ControleBord) && ActieToegestaan(LoopLocaties, LocatienaarPunt(locatie, ControleBord)))
            {
                foreach(SchaakStuk stuk in Bord)
                {
                    if (stuk.locatie == GeselecteerdeLocatie)
                    {
                        StukheeftBewogen = stuk.HeeftBewogen;
                        OudPunt = stuk.locatie;
                        stuk.HeeftBewogen = true;
                        stuk.locatie = LocatienaarPunt(locatie, ControleBord);
                        if (CheckSchaak())
                        {
                            MessageBox.Show("dan sta je schaak");
                            stuk.HeeftBewogen = StukheeftBewogen;
                            stuk.locatie = OudPunt;
                            GeselecteerdeLocatie = new Point(0, 0);
                            SlaanLocaties.Clear();
                            LoopLocaties.Clear();
                            break;
                        }
                        WisselBeurt();
                        GeselecteerdeLocatie = new Point(0,0);
                        if (CheckSchaak())
                        {
                            MessageBox.Show("De tegenstander staat Schaak");
                        }
                    }
                }
            }
            else if (InBox(locatie, ControleBord) && ActieToegestaan(SlaanLocaties, LocatienaarPunt(locatie, ControleBord)))
            {
                int count = 0;
                foreach (SchaakStuk stuk in Bord)
                {
                    if (stuk.locatie == LocatienaarPunt(locatie, ControleBord))
                    {
                        break;
                    }
                    count++;
                }

                Bord.RemoveAt(count);

                foreach (SchaakStuk stuk in Bord)
                {
                    if (stuk.locatie == GeselecteerdeLocatie)
                    {
                        StukheeftBewogen = stuk.HeeftBewogen;
                        OudPunt = stuk.locatie;
                        stuk.HeeftBewogen = true;
                        stuk.locatie = LocatienaarPunt(locatie, ControleBord);
                        if (CheckSchaak())
                        {
                            MessageBox.Show("Dan sta je schaak");
                            stuk.HeeftBewogen = StukheeftBewogen;
                            stuk.locatie = OudPunt;
                            GeselecteerdeLocatie = new Point(0, 0);
                            SlaanLocaties.Clear();
                            LoopLocaties.Clear();
                            break;
                        }
                        WisselBeurt();
                        GeselecteerdeLocatie = new Point(0, 0);
                        if (CheckSchaak())
                        {
                            MessageBox.Show("De tegenstander staat Schaak");
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        private bool CheckKleur(Point locatie)
        {
            foreach (SchaakStuk stuk in Bord)
            {
                if (locatie == stuk.locatie)
                {
                    if (stuk.kleur == HuidigeSpeler)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool ActieToegestaan(List<Point> Locaties, Point locatie)
        {
            foreach (Point punt in Locaties)
            {
                if (locatie == punt)
                {
                    return true;
                }
            }
            return false;
        }

        private bool InBox(Point locatie, Rectangle ControleBord)
        {
            return (locatie.X > ControleBord.X && locatie.X < ControleBord.X + ControleBord.Width && locatie.Y > ControleBord.Y && locatie.Y < ControleBord.Y + ControleBord.Height);
        }

        private Point LocatienaarPunt(Point locatie, Rectangle ControleBord)
        {
            return new Point((locatie.Y - ControleBord.Y) / (ControleBord.Height / 8) + 1, (locatie.X - ControleBord.X) / (ControleBord.Width / 8) + 1);
        }

        private void WisselBeurt()
        {
            if (HuidigeSpeler == Kleur.Wit)
            {
                HuidigeSpeler = Kleur.Zwart;
            }
            else
            {
                HuidigeSpeler = Kleur.Wit;
            }
        }

        private bool CheckSchaak()
        {
            Point VijandelijkeKoningLocatie = new Point();
            foreach (SchaakStuk stuk in Bord)
            {
                if ((stuk.kleur == HuidigeSpeler && stuk.type == Type.Koning))
                {
                    VijandelijkeKoningLocatie = stuk.locatie;
                }
            }
            
            foreach (SchaakStuk stuk in Bord)
            {
                if (stuk.kleur != HuidigeSpeler)
                {
                    WisselBeurt();
                    VindLocaties(stuk.locatie);
                    WisselBeurt();

                    foreach (Point locatie in SlaanLocaties)
                    {
                        if (locatie == VijandelijkeKoningLocatie)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool CheckMat()
        {
            return false;
        }
    }
}