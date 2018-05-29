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

        List<BordKnop> Knoppen = new List<BordKnop>();
        public SpelSelectie()
        {

            Knoppen.Add(new BordKnop("selecteer-spel-cirkel" , "Controller", new Point(500, 210), OpstartScherm.ActiefScherm.SpelSelectie));


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

            if (OpstartScherm.actiefscherm != OpstartScherm.ActiefScherm.Exit)
            {
                this.Close();
            }
        }
    }
}
