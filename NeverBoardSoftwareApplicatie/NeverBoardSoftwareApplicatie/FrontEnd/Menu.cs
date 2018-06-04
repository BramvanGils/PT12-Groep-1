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
    public partial class Menu : Form
    {
        private bool InOpeningstransitie = true;
        private Color AchterGrondKleur = Color.Brown;
        private List<BordKnop> Knoppen = new List<BordKnop>();

        public Menu()
        {
            // Initialisatie van het Form
            VoegKnoppenToe();
            VoegControlsToe();
            InitializeComponent();
        }

        private void VoegKnoppenToe()
        {
            Knoppen.Add(new BordKnop("selecteer-spel-cirkel", "Controller", new Point(500, 210), OpstartScherm.ActiefScherm.SpelSelectie));
            Knoppen.Add(new BordKnop("Credits-cirkel", "Credits", new Point(1400, 50), OpstartScherm.ActiefScherm.Schaakbord));
            Knoppen.Add(new BordKnop("Gebruiker-cirkel", "User", new Point(1200, 500), OpstartScherm.ActiefScherm.NieuwGebruiker));
            Knoppen.Add(new BordKnop("Instellingen-cirkel", "instellingen", new Point(80, 600), OpstartScherm.ActiefScherm.BordInstellingen));
            Knoppen.Add(new BordKnop("Afsluiten-cirkel", "Afsluiten", new Point(50, 100), OpstartScherm.ActiefScherm.Exit));
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
