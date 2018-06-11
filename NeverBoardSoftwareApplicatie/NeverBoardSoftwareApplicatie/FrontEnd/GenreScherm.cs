using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    public partial class GenreScherm : Form
    {
        private bool InOpeningstransitie = true;
        private Color AchterGrondKleur = Color.Brown;
        private List<BordKnop> Knoppen = new List<BordKnop>();

        public GenreScherm()
        {
            // Initialisatie van het Form
            VoegKnoppenToe();
            VoegControlsToe();
            InitializeComponent();
        }

        private void VoegKnoppenToe()
        {
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(0, 0), OpstartScherm.ActiefScherm.Menu));//template for back button
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(1700, 800), OpstartScherm.ActiefScherm.Menu));//template for back button
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
    }
}
