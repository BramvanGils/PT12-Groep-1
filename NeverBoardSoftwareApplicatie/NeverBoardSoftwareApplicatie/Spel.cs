using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBoardSoftwareApplicatie
{
    class Spel
    {
        private int id;
        private string naam;
        private string genre;
        private int duur;
        private int aantalSpelers;
        private string omschijving;

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

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int Duur
        {
            get { return duur; }
            set { duur = value; }
        }

        public int AantalSpelers
        {
            get { return aantalSpelers; }
            set { aantalSpelers = value; }
        }

        public string Omschrijving
        {
            get { return omschijving; }
            set { omschijving = value; }
        }

        public Spel()
        {
        }
    }
}
