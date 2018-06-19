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
        static SolidBrush SpeelBordRand = new SolidBrush(Color.Black);
        static Pen SpeelVakRand = new Pen(Color.Brown, 1);
        static SolidBrush WitVak = new SolidBrush(Color.White);
        static SolidBrush ZwartVak = new SolidBrush(Color.Black);
        static SolidBrush Selectkleur = new SolidBrush(Color.Yellow);
        static SolidBrush SelectLoopKleur = new SolidBrush(Color.Blue);
        static SolidBrush SelectSlaKleur = new SolidBrush(Color.Red);

        // Vormen
        static Rectangle Speelbord = new Rectangle(480, 60, 960, 960);
        static Rectangle controleBord1 = new Rectangle(40, 380, 320, 320);
        static Rectangle controleBord2 = new Rectangle(1560, 380, 320, 320);

        // Witte SpeelStukken
        static Image PionWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionW.png");
        static Image TorenWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenW.png");
        static Image PaardWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardW.png");
        static Image LoperWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperW.png");
        static Image KoniginWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginW.png");
        static Image KoningWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningW.png");

        // Zwarte SpeelStukken
        static Image PionZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionZ.png");
        static Image TorenZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenZ.png");
        static Image PaardZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardZ.png");
        static Image LoperZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperZ.png");
        static Image KoniginZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginZ.png");
        static Image KoningZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningZ.png");


        static public void UpdateSchaakspel(Graphics gfx, SchaakSpel spel)
        {
            TekenBord(gfx, spel.Bord);
            TekenStatusen(gfx, spel.LoopLocaties, spel.SlaanLocaties, spel.HuidigeSpeler, spel.speler1Wit);
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

        private static void TekenStatusen(Graphics graphics, List<Point> lopen, List<Point> slaan, SchaakSpel.Kleur HuidigeSpeler, bool Speler1Wit)
        {
            foreach (Point punt in lopen)
            {
                if (HuidigeSpeler == SchaakSpel.Kleur.Wit == Speler1Wit)
                {
                    graphics.FillEllipse(SelectLoopKleur, PointNaarVak(punt, 1));
                }
                else
                {
                    graphics.FillEllipse(SelectLoopKleur, PointNaarVak(punt, 2));
                }
            }
            foreach (Point punt in slaan)
            {
                if (HuidigeSpeler == SchaakSpel.Kleur.Wit == Speler1Wit)
                {
                    graphics.FillEllipse(SelectSlaKleur, PointNaarVak(punt, 1));
                }
                else
                {
                    graphics.FillEllipse(SelectSlaKleur, PointNaarVak(punt, 2));
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
