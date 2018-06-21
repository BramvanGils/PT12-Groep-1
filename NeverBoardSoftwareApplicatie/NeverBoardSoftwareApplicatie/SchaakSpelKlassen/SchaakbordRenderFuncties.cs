using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeverBoardSoftwareApplicatie
{
    public static class SchaakbordRenderFuncties
    {
        // Kleuren
        private static SolidBrush SpeelBordRand = new SolidBrush(Color.Black);
        private static Pen SpeelVakRand = new Pen(Color.Brown, 1);
        public static SolidBrush WitVak = new SolidBrush(Color.FromArgb(233,205,165));
        public static SolidBrush ZwartVak = new SolidBrush(Color.FromArgb(117,52,16));
        private static SolidBrush Selectkleur = new SolidBrush(Color.Yellow);
        private static SolidBrush SelectLoopKleur = new SolidBrush(Color.Blue);
        private static SolidBrush SelectSlaKleur = new SolidBrush(Color.Red);

        // Vormen
        public static Rectangle Speelbord = new Rectangle(480, 60, 960, 960);
        public static Rectangle controleBord1 = new Rectangle(40, 380, 320, 320);
        public static Rectangle controleBord2 = new Rectangle(1560, 380, 320, 320);

        // Witte SpeelStukken
        private static Image PionWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionW.png");
        private static Image TorenWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenW.png");
        private static Image PaardWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardW.png");
        private static Image LoperWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperW.png");
        private static Image KoniginWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginW.png");
        private static Image KoningWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningW.png");

        // Zwarte SpeelStukken
        private static Image PionZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionZ.png");
        private static Image TorenZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenZ.png");
        private static Image PaardZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardZ.png");
        private static Image LoperZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperZ.png");
        private static Image KoniginZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginZ.png");
        private static Image KoningZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningZ.png");

        static public void UpdateSchaakspel(Graphics gfx, SchaakSpel spel)
        {
            TekenBord(gfx, spel.Bord);
            TekenStatusen(gfx, spel.LoopLocaties, spel.SlaanLocaties, spel.HuidigeSpeler, spel.speler1Wit, spel.GeselecteerdeLocatie);
            TekenSpeelStukken(gfx, spel.Bord);
        }

        static public void TekenBord(Graphics graphics, List<SchaakStuk> Bord)
        {
            graphics.FillRectangle(SpeelBordRand, Speelbord);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        graphics.FillRectangle(WitVak, new Rectangle(Speelbord.X + 40 + 110 * x, Speelbord.Y + 40 + 110 * y, 110, 110));
                    }
                    else
                    {
                        graphics.FillRectangle(ZwartVak, new Rectangle(Speelbord.X + 40 + 110 * x, Speelbord.Y + 40 + 110 * y, 110, 110));
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if ((x + y) % 2 == 0)
                        {
                            graphics.FillRectangle(WitVak, new Rectangle(40 + 40 * x + 1520 * i, 380 + 40 * y, 40, 40));
                        }
                        else
                        {
                            graphics.FillRectangle(ZwartVak, new Rectangle(40 + 40 * x + 1520 * i, 380 + 40 * y, 40, 40));
                        }
                    }
                }
            }
        }

        static private void TekenSpeelStukken(Graphics graphics, List<SchaakStuk> Bord)
        {
            foreach (SchaakStuk schaakstuk in Bord)
            {
                graphics.DrawImage(GetImage(schaakstuk.type, schaakstuk.kleur), PointNaarVak(schaakstuk.locatie, 1));
                graphics.DrawImage(GetImage(schaakstuk.type, schaakstuk.kleur), PointNaarVak(schaakstuk.locatie, 2));
            }
        }

        private static void TekenStatusen(Graphics graphics, List<Point> lopen, List<Point> slaan, SchaakSpel.Kleur HuidigeSpeler, bool Speler1Wit, Point SelectieLocatie)
        {
            if (SelectieLocatie != new Point(0, 0))
            {
                int Speler;
                if (HuidigeSpeler == SchaakSpel.Kleur.Wit == Speler1Wit)
                {
                    Speler = 1;
                }
                else
                {
                    Speler = 2;
                }

                graphics.FillEllipse(Selectkleur, PointNaarVak(SelectieLocatie, Speler));
                foreach (Point punt in lopen)
                {
                    graphics.FillEllipse(SelectLoopKleur, PointNaarVak(punt, Speler));
                }
                foreach (Point punt in slaan)
                {
                    graphics.FillEllipse(SelectSlaKleur, PointNaarVak(punt, Speler));
                }
            }
        }

        private static Rectangle PointNaarVak(Point punt,int BordNummer)
        {
            if (BordNummer == 1)
            {
                return new Rectangle(controleBord1.X + (punt.Y - 1) * (controleBord1.Width / 8), controleBord1.Y + (punt.X - 1) * (controleBord1.Height / 8), controleBord1.Width / 8, controleBord1.Height / 8);
            }
            else
            {
                return new Rectangle(controleBord2.X + (punt.Y - 1) * (controleBord2.Width / 8), controleBord2.Y + (punt.X - 1) * (controleBord2.Height / 8), controleBord2.Width / 8, controleBord2.Height / 8);
            }
        }

        static private Image GetImage(SchaakSpel.Type type, SchaakSpel.Kleur kleur)
        {
            Image afbeelding;
            switch (type)
            {
                case SchaakSpel.Type.Pion:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = PionWit;
                    }
                    else
                    {
                        afbeelding = PionZwart;
                    }
                    break;
                case SchaakSpel.Type.Toren:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = TorenWit;
                    }
                    else
                    {
                        afbeelding = TorenZwart;
                    }
                    break;
                case SchaakSpel.Type.Paard:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = PaardWit;
                    }
                    else
                    {
                        afbeelding = PaardZwart;
                    }
                    break;
                case SchaakSpel.Type.Loper:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = LoperWit;
                    }
                    else
                    {
                        afbeelding = LoperZwart;
                    }
                    break;
                case SchaakSpel.Type.Konigin:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = KoniginWit;
                    }
                    else
                    {
                        afbeelding = KoniginZwart;
                    }
                    break;
                case SchaakSpel.Type.Koning:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        afbeelding = KoningWit;
                    }
                    else
                    {
                        afbeelding = KoningZwart;
                    }
                    break;
                default:
                    return null;
            }
            afbeelding.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return afbeelding;
        }
    }
}
