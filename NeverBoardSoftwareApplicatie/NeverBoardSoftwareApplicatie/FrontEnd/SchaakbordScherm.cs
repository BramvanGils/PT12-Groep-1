using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace NeverBoardSoftwareApplicatie
{
    public partial class SchaakbordScherm : Form
    {
        Graphics graphics;

        private bool InOpeningstransitie = true;
        private List<BordKnop> Knoppen = new List<BordKnop>();
        private SchaakSpel schaakSpel;

        public SoundPlayer player = new SoundPlayer();

        public SchaakbordScherm()
        {
            // Initialisatie van het Form
            schaakSpel = new SchaakSpel(true, this);
            UpdateScherm();
            VoegKnoppenToe();
            VoegControlsToe();
            InitializeComponent();
        }

        private void VoegKnoppenToe()
        {

        }

        private void UpdateScherm()
        {
            BackgroundImage = new Bitmap(1920,1080);
            graphics = Graphics.FromImage(BackgroundImage);
            SchaakbordRenderFuncties.UpdateSchaakspel(graphics, schaakSpel);
        }

        private void VoegControlsToe()
        {
            foreach (BordKnop Knop in Knoppen)
            {
                Controls.Add(Knop.Kader);
            }
        }

        private void AnimatieTimer_Tick(object sender, EventArgs e)
        {
            if (OpstartScherm.actiefscherm != OpstartScherm.ActiefScherm.Actief)
            {
                Opacity -= 0.04;

                if (Opacity <= 0)
                {
                    this.Close();
                }
            }

            if (InOpeningstransitie)
            {
                Opacity += 0.04;

                if (Opacity >= 1)
                {
                    InOpeningstransitie = false;
                }
            }

            foreach (BordKnop Knop in Knoppen)
            {
                Knop.UpdateAfbeelding();
            }
        }

        private void SchaakbordScherm_MouseClick(object sender, MouseEventArgs e)
        {
            if (schaakSpel.VerwerkKlik(MousePosition))
            {
                UpdateScherm();
            }
        }
    }
}
