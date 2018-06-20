using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    class DatabaseManager
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Spelers.mdf;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connectionString);
        private List<Gebruiker> gebruikers = new List<Gebruiker>();
        private List<Groep> groepen = new List<Groep>();
        private List<Spel> spellen = new List<Spel>();

        public List<Gebruiker> VraagGebruikerID()
        {
            conn.Open();
            string Query = "SELECT ID FROM Gebruiker";
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                    gebruiker.ID = (reader.GetInt32(0));
                    gebruiker.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Gebruiker> VraagInfoGebruiker(int ID)
        {
            conn.Open();
            string Query = "SELECT Naam, Accountkleur, Profielfoto FROM Gebruiker WHERE ID = " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                    gebruiker.ID = (reader.GetInt32(0));
                    gebruiker.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Groep> VraagGroepID()
        {
            conn.Open();
            string Query = "SELECT ID FROM Groep";
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Groep groep = new Groep();
                    groepen.Add(groep);
                    groep.ID = (reader.GetInt32(0));
                    groep.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return groepen;
        }

        public List<Groep> VraagInfoGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT Naam, Groepskleur FROM Groep WHERE ID = " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Groep groep = new Groep();
                    groepen.Add(groep);
                    groep.ID = (reader.GetInt32(0));
                    groep.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return groepen;
        }

        public List<Spel> FilterGenre(string genre)
        {
            conn.Open();
            string Query = "SELECT * FROM Spel WHERE Genre like '" + genre + "'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Spel spel = new Spel();
                    spellen.Add(spel);
                    spel.ID = (reader.GetInt32(0));
                    spel.Naam = (reader.GetString(1));
                    spel.Genre = (reader.GetString(2));
                    spel.Duur = (reader.GetInt32(3));
                    spel.AantalSpelers = (reader.GetInt32(4));
                    spel.Omschrijving = (reader.GetString(5));
                }
            }
            conn.Close();
            return spellen;
        }

        public List<Gebruiker> VraagGebruikersVanGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT GebruikerID FROM GebruikerGroep INNER JOIN Gebruiker ON GebruikerGroep.GebruikerID = Gebruiker.ID INNER JOIN Groep ON GebruikerGroep.GroepID = Groep.ID WHERE Gebruiker.ID = " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                    gebruiker.ID = (reader.GetInt32(0));
                    gebruiker.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Gebruiker> VraagGebruikersNietVanGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT GebruikerID FROM GebruikerGroep INNER JOIN Gebruiker ON GebruikerGroep.GebruikerID = Gebruiker.ID INNER JOIN Groep ON GebruikerGroep.GroepID = Groep.ID WHERE Gebruiker.ID != " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                    gebruiker.ID = (reader.GetInt32(0));
                    gebruiker.Naam = (reader.GetString(1));
                }
            }
            conn.Close();
            return gebruikers;
        }

        public void 
    }
}
