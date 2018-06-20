﻿using System;
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
        private int rood;
        private int groen;
        private int blauw;
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

        public int Rood
        {
            get { return rood; }
            set { rood = value; }
        }

        public int Groen
        {
            get { return groen; }
            set { groen = value; }
        }

        public int Blauw
        {
            get { return blauw; }
            set { blauw = value; }
        }

        public Groep()
        {
        }
    }
}
