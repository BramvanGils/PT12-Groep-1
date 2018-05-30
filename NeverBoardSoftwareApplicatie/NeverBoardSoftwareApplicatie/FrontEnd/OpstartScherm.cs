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
    public partial class OpstartScherm : Form
    {

        public enum ActiefScherm {Actief, Exit, OpstartScherm, Menu, SpelSelectie, Instellingen, CreditsNeverboard, NieuwGebruiker, BordInstellingen,SpelMenu, Schaakbord, };
        public static ActiefScherm actiefscherm = ActiefScherm.Menu;
        public OpstartScherm()
        {
            InitializeComponent();

            Show();
            Hide();
            Show();

            IntroPictureBox.BackColor = Color.Transparent;

            actiefscherm = ActiefScherm.Menu;
            while (true)
            {
                OpenScherm();
            }
        }

        private void AnimatieTimer_Tick(object sender, EventArgs e)
        {
            
        }

        public void OpenScherm()
        {
            switch (actiefscherm)
            {
                case ActiefScherm.OpstartScherm:
                    
                    break;
                case ActiefScherm.Menu:
                    actiefscherm = ActiefScherm.Actief;
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    break;
                case ActiefScherm.SpelSelectie:
                    actiefscherm = ActiefScherm.Actief;
                    SpelSelectie spelselectie = new SpelSelectie();
                    spelselectie.ShowDialog();
                    break;
                case ActiefScherm.Instellingen:
                    actiefscherm = ActiefScherm.Actief;
                    
                    break;
                case ActiefScherm.CreditsNeverboard:
                    actiefscherm = ActiefScherm.Actief;
                    CreditsNeverboard creditsneverboard = new CreditsNeverboard();
                    creditsneverboard.ShowDialog();
                    break;
                case ActiefScherm.NieuwGebruiker:
                    actiefscherm = ActiefScherm.Actief;
                    NieuweGebruiker nieuweGebruiker = new NieuweGebruiker();
                    nieuweGebruiker.ShowDialog();
                    break;
                case ActiefScherm.BordInstellingen:
                    actiefscherm = ActiefScherm.Actief;
                    BordInstellingen bordinstellingen = new BordInstellingen();
                    bordinstellingen.ShowDialog();
                    break;
                case ActiefScherm.SpelMenu:
                    actiefscherm = ActiefScherm.Actief;

                    break;
                case ActiefScherm.Schaakbord:
                    actiefscherm = ActiefScherm.Actief;

                    break;
                case ActiefScherm.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
