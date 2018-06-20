using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBoardSoftwareApplicatie
{
    class Gebruiker
    {
        private int id;
        private string naam;
        //private ??? Accountkleur;
        //private ??? Profielfoto;

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

        public Gebruiker()
        {
        }
    }
}
