using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    class Groep : PictureBox
    {
        private int id;
        private string naam;
        private List<Gebruiker> gebruikers = new List<Gebruiker>();
        //private ??? Groepskleur;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public Groep(List<Gebruiker> groepsLeden)
        {
            gebruikers = groepsLeden;
        }
        public Groep(int ID)
        {
            id = ID;
        }
        public Groep()
        {
        }
    }
}
