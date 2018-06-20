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
    public partial class SpelSelectie : Form
    {
        private bool InOpeningstransitie = true;
        public List<BordKnop> Knoppen = new List<BordKnop>();
        public SpelSelectie()
        {
            // Initialisatie van het Form
            VoegKnoppenToe();
            VoegControlsToe();
            InitializeComponent();
        }

        private void VoegKnoppenToe()
        {
            Knoppen.Add(new BordKnop("favorieten-cirkel", "Favorieten", new Point(827, 407), OpstartScherm.ActiefScherm.Genrescherm));//template Favourite
            Knoppen.Add(new BordKnop("Strategie-cirkel", "Strategie", new Point(812, 7), OpstartScherm.ActiefScherm.Genrescherm));//template Strategie
            Knoppen.Add(new BordKnop("Familie-cirkel", "Familie", new Point(434, 284), OpstartScherm.ActiefScherm.Genrescherm));//template Familie
            Knoppen.Add(new BordKnop("Jeugd-cirkel", "jeugd", new Point(1184, 284), OpstartScherm.ActiefScherm.Genrescherm));//template Jeugd
            Knoppen.Add(new BordKnop("Gokken-cirkel", "Gokken", new Point(585, 721), OpstartScherm.ActiefScherm.Genrescherm));//template Gokken
            Knoppen.Add(new BordKnop("Feest-cirkel", "Feest", new Point(1064, 721), OpstartScherm.ActiefScherm.Genrescherm));//template Feest
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(0, 0), OpstartScherm.ActiefScherm.Menu));//template for back button
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(1690,840), OpstartScherm.ActiefScherm.Menu));//template for back button
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
