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
        public enum ActiefScherm {Actief, Exit, OpstartScherm, Menu, SpelSelectie, Instellingen, CreditsNeverboard, NieuwGebruiker, BordInstellingen,SpelMenu, Schaakbord, Genrescherm };
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
                    using (Menu menu = new Menu())
                    { menu.ShowDialog(); }
                    break;
                case ActiefScherm.SpelSelectie:
                    actiefscherm = ActiefScherm.Actief;
                    using (SpelSelectie spelSelectie = new SpelSelectie())
                    { spelSelectie.ShowDialog(); }
                    break;
                case ActiefScherm.Instellingen:
                    actiefscherm = ActiefScherm.Actief;
                    
                    break;
                case ActiefScherm.CreditsNeverboard:
                    actiefscherm = ActiefScherm.Actief;
                    using (CreditsNeverboard creditsNeverboard = new CreditsNeverboard())
                    { creditsNeverboard.ShowDialog(); }
                    break;
                case ActiefScherm.NieuwGebruiker:
                    actiefscherm = ActiefScherm.Actief;
                    using (NieuweGebruiker nieuweGebruiker = new NieuweGebruiker())
                    { nieuweGebruiker.ShowDialog(); }
                    break;
                case ActiefScherm.BordInstellingen:
                    actiefscherm = ActiefScherm.Actief;
                    using (BordInstellingen bordinstellingen = new BordInstellingen())
                    { bordinstellingen.ShowDialog(); }
                    break;
                case ActiefScherm.SpelMenu:
                    actiefscherm = ActiefScherm.Actief;

                    break;
                case ActiefScherm.Schaakbord:
                    actiefscherm = ActiefScherm.Actief;
                    using (SchaakbordScherm schaakbordScherm = new SchaakbordScherm())
                    { schaakbordScherm.ShowDialog(); }
                    break;
                case ActiefScherm.Genrescherm:
                    actiefscherm = ActiefScherm.Actief;
                    using (GenreScherm genreScherm = new GenreScherm())
                    { genreScherm.ShowDialog(); }
                    break;
                case ActiefScherm.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
