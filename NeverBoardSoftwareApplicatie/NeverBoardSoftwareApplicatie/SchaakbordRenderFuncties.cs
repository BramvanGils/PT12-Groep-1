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
        Pen SpeelBordRand = new Pen(Color.Black, 3);
        Pen SpeelVakRand = new Pen(Color.Brown, 40);
        SolidBrush WitVak = new SolidBrush(Color.White);
        SolidBrush ZwartVak = new SolidBrush(Color.Black);

        // Vormen
        Rectangle Speelbord = new Rectangle(480, 60 ,960, 960);
        Rectangle controleBord1 = new Rectangle(40, 380, 320, 320);
        Rectangle controleBord2 = new Rectangle(720, 380, 320, 320);

        public Graphics TekenBord(Graphics graphics)
        {
            graphics.DrawRectangle();
            return graphics;
        }
    }
}
