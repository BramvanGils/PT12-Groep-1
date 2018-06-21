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
    public partial class GroepsSelectie : Form
    {
        private bool InOpeningstransitie = true;
        private List<Groep> groepen = new List<Groep>();
        private List<Gebruiker> gebruikers = new List<Gebruiker>();
        public List<BordKnop> Knoppen = new List<BordKnop>();
        public GroepsSelectie()
        {
            // Initialisatie van het Form
            VoegKnoppenToe();
            VoegControlsToe();
            InitializeComponent();
        }

        private void VoegKnoppenToe()
        {
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(0, 0), OpstartScherm.ActiefScherm.Menu));//template for back button
            Knoppen.Add(new BordKnop("Gebruiker-cirkel", "User", new Point(1200, 500), OpstartScherm.ActiefScherm.NieuwGebruiker));
            Knoppen.Add(new BordKnop("Strategie-cirkel", "Strategie", new Point(0, 800), OpstartScherm.ActiefScherm.SpelSelectie));//template Strategie
            Knoppen.Add(new BordKnop("Terug-cirkel", "vorige-pagina", new Point(1690, 840), OpstartScherm.ActiefScherm.Menu));//template for back button
        }

        private void VoegControlsToe()
        {
            foreach (BordKnop Knop in Knoppen)
            {
                Controls.Add(Knop.Kader);
            }
        }

        public void getGroupIDs()
        {
            int i = 0;
            groepen = DatabaseManager.VraagGroepID();
            foreach (Groep groep in groepen)
            {
                groepen.Add(new Groep());
                i++;
            }
        }

        public void MaakNieuwGroep()
        {
            DatabaseManager.MaakNieuweGroep(tbGroepNaam.Text);
        }

        private void VoegGebruikerToeAanGroup()
        {

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

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            MaakNieuwGroep();
        }
    }
}
