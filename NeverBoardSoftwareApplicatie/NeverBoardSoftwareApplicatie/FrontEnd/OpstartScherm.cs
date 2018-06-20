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
        // Enum's aanmaken
        public enum ActiefScherm {Actief, Exit, OpstartScherm, Menu, GroepsSelectie, SpelSelectie, Instellingen, CreditsNeverboard, NieuwGebruiker, BordInstellingen,SpelMenu, Schaakbord, Genrescherm };
        public enum Genre {NULL, Favoriet, Startegie, Familie, Jeugd, Gokken, Feest};

        // Enum variabelen
        public static ActiefScherm actiefscherm = ActiefScherm.Menu;
        public static ActiefScherm VorigScherm;
        public static Genre HuidigGenre;
        public static Form HuidigScherm;
        public OpstartScherm()
        {
            MaakPicturebox();
            InitializeComponent();

            Show();
            Hide();
            Show();

            actiefscherm = ActiefScherm.Menu;
            while (true)
            {
                OpenScherm();
            }
        }

        private void MaakPicturebox()
        {
            IntroPictureBox = new PictureBox();
            IntroPictureBox.Location = new Point(0, 0);
            IntroPictureBox.Size = new Size(1920, 1080);
            Controls.Add(IntroPictureBox);
        }

        private void AnimatieTimer_Tick(object sender, EventArgs e)
        {
            
        }

        public void OpenScherm()
        {
            VorigScherm = actiefscherm;
            switch (actiefscherm)
            {
                case ActiefScherm.OpstartScherm:
                    
                    break;
                case ActiefScherm.Menu:
                    actiefscherm = ActiefScherm.Actief;
                    Menu menu = new Menu();
                    HuidigScherm = menu;
                    menu.ShowDialog();
                    break;
                case ActiefScherm.SpelSelectie:
                    actiefscherm = ActiefScherm.Actief;
                    SpelSelectie spelselectie = new SpelSelectie();
                    spelselectie.ShowDialog();
                    HuidigScherm = spelselectie;
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
                case ActiefScherm.GroepsSelectie:
                    actiefscherm = ActiefScherm.Actief;
                    GroepsSelectie groepsSelectie = new GroepsSelectie();
                    groepsSelectie.ShowDialog();
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
                    SchaakbordScherm schaakbordScherm = new SchaakbordScherm();
                    schaakbordScherm.ShowDialog();

                    break;
                case ActiefScherm.Genrescherm:
                    actiefscherm = ActiefScherm.Actief;
                    GenreScherm genreScherm = new GenreScherm();
                    genreScherm.ShowDialog();

                    break;
                case ActiefScherm.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
