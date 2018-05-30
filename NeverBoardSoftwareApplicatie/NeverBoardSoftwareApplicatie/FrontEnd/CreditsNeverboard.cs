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
    public partial class CreditsNeverboard : Form
    {

        List<BordKnop> Knoppen = new List<BordKnop>();
        public CreditsNeverboard()
        {

            Knoppen.Add(new BordKnop("Credits-cirkel", "Credits", new Point(1400, 50), OpstartScherm.ActiefScherm.Menu));


            foreach (BordKnop Knop in Knoppen)
            {
                Controls.Add(Knop.Kader);
            }

            InitializeComponent();
        }

        public void OpenForm()
        {
            Show();
            Hide();
            Show();
        }

        private void AnimatieTimer_Tick(object sender, EventArgs e)
        {
            foreach (BordKnop Knop in Knoppen)
            {
                Knop.UpdateAfbeelding();
            }

            if (OpstartScherm.actiefscherm != OpstartScherm.ActiefScherm.Actief)
            {
                this.Close();
            }
        }
    }
}
