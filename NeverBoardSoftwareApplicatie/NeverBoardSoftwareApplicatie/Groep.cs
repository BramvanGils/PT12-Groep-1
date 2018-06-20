using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBoardSoftwareApplicatie
{
    class Groep
    {
        private int id;
        private string naam;
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

        public Groep()
        {
        }
    }
}
