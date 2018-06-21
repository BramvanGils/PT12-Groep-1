using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie.SchaakSpelKlassen
{
    static class AnimatieFuncties
    {
        static public void LoadFightAnimatie(SchaakSpel.Type type, Point punt, PictureBox pbox)
        {
            
        }

        static private Point PuntnaarLocatie(Point punt)
        {
            int X = SchaakbordRenderFuncties.Speelbord.X + (punt.Y - 1) * ((SchaakbordRenderFuncties.Speelbord.Width - 80) / 8) + 40;
            int Y = SchaakbordRenderFuncties.Speelbord.Y + (punt.X - 1) * ((SchaakbordRenderFuncties.Speelbord.Height -80) / 8) + 40;
            return new Point(X,Y);
        }
        
        public static Color getColor(Point punt)
        {
            if ((punt.X + punt.Y) % 2 != 1)
            {
                return Color.FromArgb(233, 205, 165);
            }
            return Color.FromArgb(117, 52, 16);
        }

        static private Image GetFightImage(SchaakSpel.Type type)
        {
            switch (type)
            {
                case SchaakSpel.Type.Pion:
                    return RetrieveGif("punch");
                case SchaakSpel.Type.Toren:
                    return RetrieveGif("Kanon2");
                case SchaakSpel.Type.Paard:
                    return RetrieveGif("Paard");
                case SchaakSpel.Type.Loper:
                    return RetrieveGif("slice");
                case SchaakSpel.Type.Konigin:
                    return RetrieveGif("Koiniging");
                case SchaakSpel.Type.Koning:
                    return RetrieveGif("Koning");
                default:
                    MessageBox.Show("Image not found");
                    return null;
            }
        }

        static public void SetSchaak(Point punt, PictureBox SchaakBox)
        {
            SchaakBox.Location = PuntnaarLocatie(punt);
            SchaakBox.Visible = true;
            SchaakBox.BackColor = getColor(punt);
        }

        static public void RemoveSchaak(PictureBox SchaakBox)
        {
            SchaakBox.Visible = false;
        }

        private static Image RetrieveGif(string BestandNaam)
        {
            return Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Gif\" + BestandNaam + ".gif");
        }
    }
}
