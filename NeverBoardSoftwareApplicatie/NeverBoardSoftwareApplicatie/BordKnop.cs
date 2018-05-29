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
    class BordKnop
    {
        OpstartScherm.ActiefScherm nieuwelocatie;
        int rotatie;
        Image Vorm;
        Image Icoon;
        public PictureBox Kader;
        Point MiddelPunt;
        Point IcoonLocatie;

        Image[] Frames = new Image[90];

        static Random rnd = new Random();

        public BordKnop(string VormNaam, string IcoonNaam ,Point Locatie, OpstartScherm.ActiefScherm NieuweLocatie)
        {
            // Picture Box
            Kader = new PictureBox();
            Kader.BackColor = Color.Transparent;
            // Afbeeldingen
            Vorm = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Knop Afbeeldingen\Knop Vormen\" + VormNaam + ".png");
            Icoon = Image.FromFile(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + @"Resources\Knop Afbeeldingen\Knop Iconen\" + IcoonNaam + ".png");
            Kader.BackColor = Color.Transparent;
            // locaties
            Kader.Height = Vorm.Height;
            Kader.Width = Vorm.Width;
            Kader.Location = Locatie;
            Kader.Image = Vorm;
            MiddelPunt = new Point(Kader.Width / 2 + Locatie.X, Kader.Height / 2 + Locatie.Y);
            IcoonLocatie = new Point(((Kader.Width - Icoon.Width) / 2),((Kader.Height - Icoon.Height) / 2));
            // Events
            Kader.Click += new EventHandler(ClickEvent);
            nieuwelocatie = NieuweLocatie;
            // Prepare images
            RenderImageSet();
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow(Cursor.Position.X - MiddelPunt.X, 2) + Math.Pow(Cursor.Position.Y - MiddelPunt.Y, 2)) < Kader.Width / 2)
            {
                Kader.Visible = false;
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
        private void RenderImageSet()
        {
            for (int frame = 0; frame < 90; frame++)
            {
                Image Frame = Kader.Image;
                Graphics gfx = Graphics.FromImage(Frame = RotateImage(Vorm, frame, false, true, Color.Transparent));
                gfx.DrawImage(RotateImage(Icoon, -frame, false, true, Color.Transparent), new Rectangle(IcoonLocatie, new Size(Icoon.Width, Icoon.Height)));
                Frames[frame] = Frame;
                gfx.Dispose();
            }
        }
        

        public static Bitmap RotateImage(Image inputImage, float angleDegrees, bool upsizeOk,bool clipOk, Color backgroundColor)
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

            // If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
            if (upsizeOk || !clipOk)
            {
                double angleRadians = angleDegrees * Math.PI / 180d;

                double cos = Math.Abs(Math.Cos(angleRadians));
                double sin = Math.Abs(Math.Sin(angleRadians));
                newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
                newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
            }

            // If upsizing not wanted and clipping not OK need a scaling factor
            if (!upsizeOk && !clipOk)
            {
                scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            // Create the new bitmap object. If background color is transparent it must be 32-bit, 
            //  otherwise 24-bit is good enough.
            Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ?
                                             PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
            newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

            // Create the Graphics object that does the work
            using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
            {
                graphicsObject.InterpolationMode = InterpolationMode.Low;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graphicsObject.SmoothingMode = SmoothingMode.HighSpeed;

                // Fill in the specified background color if necessary
                if (backgroundColor != Color.Transparent)
                    graphicsObject.Clear(backgroundColor);

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
