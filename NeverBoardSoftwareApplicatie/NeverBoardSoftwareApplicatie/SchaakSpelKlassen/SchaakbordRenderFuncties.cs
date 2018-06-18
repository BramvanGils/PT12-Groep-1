using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeverBoardSoftwareApplicatie
{
    public class SchaakbordRenderFuncties
    {
        // Kleuren
        SolidBrush SpeelBordRand = new SolidBrush(Color.Black);
        Pen SpeelVakRand = new Pen(Color.Brown, 1);
        SolidBrush WitVak = new SolidBrush(Color.White);
        SolidBrush ZwartVak = new SolidBrush(Color.Black);

        // Vormen
        Rectangle Speelbord = new Rectangle(480, 60 ,960, 960);
        Rectangle controleBord1 = new Rectangle(40, 380, 320, 320);
        Rectangle controleBord2 = new Rectangle(720, 380, 320, 320);

        // Witte SpeelStukken
        Image PionWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionW.png");
        Image TorenWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenW.png");
        Image PaardWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardW.png");
        Image LoperWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperW.png");
        Image KoniginWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginW.png");
        Image KoningWit = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningW.png");

        // Zwarte SpeelStukken
        Image PionZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PionZ.png");
        Image TorenZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\TorenZ.png");
        Image PaardZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\PaardZ.png");
        Image LoperZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\LoperZ.png");
        Image KoniginZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoniginZ.png");
        Image KoningZwart = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Schaakstukken\KoningZ.png");

        public Graphics TekenBord(Graphics graphics)
        {
            graphics.FillRectangle(SpeelBordRand,Speelbord);
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
            TekenSpeelStukken(graphics);
            return graphics;
        }

        private void TekenSpeelStukken(Graphics graphics)
        {
            //foreach(SchaakStuk schaakstuk in )
        }

        private Image GetImage(SchaakSpel.Type type, SchaakSpel.Kleur kleur)
        {
            switch (type)
            {
                case SchaakSpel.Type.Pion:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return PionWit;
                    }
                    return PionZwart;
                case SchaakSpel.Type.Toren:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return TorenWit;
                    }
                    return TorenZwart;
                case SchaakSpel.Type.Paard:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return PaardWit;
                    }
                    return PaardZwart;
                case SchaakSpel.Type.Loper:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return LoperWit;
                    }
                    return LoperZwart;
                case SchaakSpel.Type.Konigin:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return KoniginWit;
                    }
                    return KoniginZwart;
                case SchaakSpel.Type.Koning:
                    if (kleur == SchaakSpel.Kleur.Wit)
                    {
                        return KoningWit;
                    }
                    return KoningZwart;
                default:
                    return null;
            }
        }
    }
}
