using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace NeverBoardSoftwareApplicatie
{
    public class BordKnop
    {
        // Afbeelding variables
        Image Vorm;
        Image Icoon;
        Bitmap Temp;
        public PictureBox Kader;
        Point MiddelPunt;
        Point IcoonLocatie;
        int rotatie;
        Image[] Frames = new Image[90];

        // Random Class
        Random rnd = new Random();

        // Form Managment
        OpstartScherm.ActiefScherm nieuwelocatie;
        OpstartScherm.Genre nieuwGenre = OpstartScherm.Genre.NULL;

        // Animatie Managment
        Color AchtergrondKleur;

        public BordKnop(string VormNaam, string IcoonNaam, Point Locatie, OpstartScherm.ActiefScherm NieuweLocatie)
        {
            BereidAfbeeldingenVoor(VormNaam, IcoonNaam, Locatie, NieuweLocatie);
            DraaiIcoon();
            RenderAfbeeldingenSet();
        }

        public BordKnop(string VormNaam, string IcoonNaam, Point Locatie, OpstartScherm.ActiefScherm NieuweLocatie , OpstartScherm.Genre NieuwGenre)
        {
            nieuwGenre = NieuwGenre;
            BereidAfbeeldingenVoor(VormNaam, IcoonNaam, Locatie, NieuweLocatie);
            DraaiIcoon();
            RenderAfbeeldingenSet();
        }

        private void BereidAfbeeldingenVoor(string VormNaam, string IcoonNaam, Point Locatie, OpstartScherm.ActiefScherm NieuweLocatie)
        {

            // Picture Box
            Kader = new PictureBox();
            Kader.BackColor = Color.Transparent;
            // Afbeeldingen
            Vorm = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Knop Afbeeldingen\Knop Vormen\" + VormNaam + ".png");
            Icoon = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Knop Afbeeldingen\Knop Iconen\" + IcoonNaam + ".png");
            // Locaties
            Kader.Height = Vorm.Height;
            Kader.Width = Vorm.Width;
            Kader.Location = Locatie;
            Kader.Image = Vorm;
            MiddelPunt = new Point(Kader.Width / 2 + Locatie.X, Kader.Height / 2 + Locatie.Y);
            IcoonLocatie = new Point(((Kader.Width - Icoon.Width) / 2), ((Kader.Height - Icoon.Height) / 2));
            // Events
            Kader.Click += new EventHandler(ClickEvent);
            nieuwelocatie = NieuweLocatie;
            // Bereken kleur van de Vorm van de knop
            Temp = (Bitmap)Vorm;
            AchtergrondKleur = Temp.GetPixel(Vorm.Width / 2, 5);
            
        }

        private void DraaiIcoon()
        {
            switch (rnd.Next(0,4))
            {
                case 0:

                    break;
                case 1:
                    Icoon.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 2:
                    Icoon.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 3:
                    Icoon.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
        }


        private void ClickEvent(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow(Cursor.Position.X - MiddelPunt.X, 2) + Math.Pow(Cursor.Position.Y - MiddelPunt.Y, 2)) < Kader.Width / 2 && OpstartScherm.actiefscherm == OpstartScherm.ActiefScherm.Actief)
            {
                if (nieuwGenre != OpstartScherm.Genre.NULL)
                {
                    OpstartScherm.HuidigGenre = nieuwGenre;
                }
                OpstartScherm.IntroPictureBox.BackColor = AchtergrondKleur;
                OpstartScherm.actiefscherm = nieuwelocatie;
            }
        }

        public void UpdateAfbeelding()
        {
            Frames[rotatie % 90].RotateFlip(RotateFlipType.Rotate270FlipNone);
            Kader.Image = Frames[rotatie % 90];
            rotatie++;
        }

        // Maak graphics aan en roteer afbeelding in een Array
        private void RenderAfbeeldingenSet()
        {
            for (int frame = 0; frame < 90; frame++)
            {
                Image Frame = Kader.Image;
                Graphics gfx = Graphics.FromImage(Frame = RotateImage(Vorm, frame));
                gfx.DrawImage(RotateImage(Icoon, -frame), new Rectangle(IcoonLocatie, new Size(Icoon.Width, Icoon.Height)));
                Frames[frame] = Frame;
                gfx.Dispose();
            }
        }

        /// <summary>
        /// Gevonden op internet terwijl ik op zoek was naar een oplossing voor de rotatie.
        /// Onderstaande URL refereert naar de onderstaande methode.
        /// https://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-winforms
        /// </summary>
        /// <param name="inputImage"></param>
        /// <param name="angleDegrees"></param>
        /// <param name="upsizeOk"></param>
        /// <param name="clipOk"></param>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        public static Bitmap RotateImage(Image inputImage, float angleDegrees)
        {
            // Test for zero rotation and return a clone of the input image
            if (angleDegrees == 0f)
                return (Bitmap)inputImage.Clone();

            // Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
            int oldWidth = inputImage.Width;
            int oldHeight = inputImage.Height;
            int newWidth = oldWidth;
            int newHeight = oldHeight;
            float scaleFactor = 1f;

            // Create the new bitmap object. If background color is transparent it must be 32-bit, 
            //  otherwise 24-bit is good enough.
            Bitmap newBitmap = new Bitmap(newWidth, newHeight,PixelFormat.Format32bppArgb);
            newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

            // Create the Graphics object that does the work
            using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
            {
                graphicsObject.InterpolationMode = InterpolationMode.Low;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graphicsObject.SmoothingMode = SmoothingMode.HighSpeed;


                // Set up the built-in transformation matrix to do the rotation and maybe scaling
                graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);

                if (scaleFactor != 1f)
                    graphicsObject.ScaleTransform(scaleFactor, scaleFactor);

                graphicsObject.RotateTransform(angleDegrees);
                graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

                // Draw the result 
                graphicsObject.DrawImage(inputImage, 0, 0);
            }
            return newBitmap;
        }
    }
}
