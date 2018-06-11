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

            return graphics;
        }
    }
}
