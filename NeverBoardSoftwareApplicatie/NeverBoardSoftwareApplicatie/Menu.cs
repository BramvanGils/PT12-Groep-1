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
        List<BordKnop> Knoppen = new List<BordKnop>();
        public Menu()
        {
            Knoppen.Add(new BordKnop("selecteer-spel-cirkel" , "Controller", new Point(500, 210)));
            Knoppen.Add(new BordKnop("Credits-cirkel", "Credits", new Point(1400, 50)));
            Knoppen.Add(new BordKnop("Gebruiker-cirkel", "User", new Point(1200, 500)));
            Knoppen.Add(new BordKnop("Instellingen-cirkel", "instellingen", new Point(80, 600)));
            Knoppen.Add(new BordKnop("score-cirkel", "crown", new Point(50, 100)));


            foreach (BordKnop Knop in Knoppen)
            {
                Controls.Add(Knop.Kader);
            }

            InitializeComponent();
            
            Show();
            Hide();
            Show();
        }

        private void AnimatieTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            foreach (BordKnop Knop in Knoppen)
            {
                Knop.UpdateAfbeelding();
            }
        }
    }
}
