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

        public enum ActiefScherm {Exit, OpstartScherm, Menu, SpelSelectie, Instellingen, CreditsNeverboard, NieuwGebruiker, BordInstellingen, LeaderBoard,SpelMenu, Schaakbord, };
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
                    actiefscherm = ActiefScherm.Exit;
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    break;
                case ActiefScherm.SpelSelectie:
                    actiefscherm = ActiefScherm.Exit;
                    SpelSelectie spelselectie = new SpelSelectie();
                    spelselectie.ShowDialog();
                    break;
                case ActiefScherm.Instellingen:
                    actiefscherm = ActiefScherm.Exit;
                    
                    break;
                case ActiefScherm.CreditsNeverboard:
                    actiefscherm = ActiefScherm.Exit;
                    CreditsNeverboard creditsneverboard = new CreditsNeverboard();
                    creditsneverboard.ShowDialog();
                    break;
                case ActiefScherm.NieuwGebruiker:
                    actiefscherm = ActiefScherm.Exit;
                    NieuweGebruiker nieuweGebruiker = new NieuweGebruiker();
                    nieuweGebruiker.ShowDialog();
                    break;
                case ActiefScherm.BordInstellingen:
                    actiefscherm = ActiefScherm.Exit;
                    BordInstellingen bordinstellingen = new BordInstellingen();
                    bordinstellingen.ShowDialog();
                    break;
                case ActiefScherm.SpelMenu:
                    actiefscherm = ActiefScherm.Exit;

                    break;
                case ActiefScherm.Schaakbord:
                    actiefscherm = ActiefScherm.Exit;

                    break;
                case ActiefScherm.LeaderBoard:
                    actiefscherm = ActiefScherm.Exit;
                    LeaderBoard leaderBoard = new LeaderBoard();
                    leaderBoard.ShowDialog();
                    break;
                default:
                    this.Close();
                    break;
            }
        }
    }
}
