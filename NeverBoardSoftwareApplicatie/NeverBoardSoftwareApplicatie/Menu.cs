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
            Knoppen.Add(new BordKnop("selecteer-spel-cirkel" , "Controller", new Point(330, 330)));

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
            foreach (BordKnop Knop in Knoppen)
            {
                Knop.RotateImage();
            }
        }
    }
}
