using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NeverBoardSoftwareApplicatie
{
    class DatabaseManager
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Spelers.mdf;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connectionString);
        private List<Gebruiker> gebruikers = new List<Gebruiker>();
        private List<Groep> groepen = new List<Groep>();

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
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Gebruiker> VraagInfoGebruiker(int ID)
        {
            conn.Open();
            string Query = "SELECT Naam, Kleur, Foto FROM Gebruiker WHERE ID = " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
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
                }
            }
            conn.Close();
            return groepen;
        }

        public List<Groep> VraagInfoGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT Naam, Kleur, Foto FROM Groep WHERE ID = " + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Groep groep = new Groep();
                    groepen.Add(groep);
                }
            }
            conn.Close();
            return groepen;
        }

        public List<Gebruiker> FilterGenre(string genre)
        {
            conn.Open();
            string Query = "SELECT * FROM Spel WHERE genre = " + genre;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Gebruiker> VraagGebruikersVanGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT * FROM Groep INNER JOIN Gebruiker ON Gebruiker_Groep.GebruikerID = Gebruiker.GebruikerID INNER JOIN Groep ON Gebruiker_Groep.GroepID = Groep.[GroepID] WHERE Gebruiker.GebruikerID = Groep." + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                }
            }
            conn.Close();
            return gebruikers;
        }

        public List<Gebruiker> VraagGebruikersNietVanGroep(int ID)
        {
            conn.Open();
            string Query = "SELECT * FROM Groep INNER JOIN Gebruiker ON Gebruiker_Groep.GebruikerID = Gebruiker.GebruikerID INNER JOIN Groep ON Gebruiker_Groep.GroepID = Groep.[GroepID] WHERE Gebruiker.GebruikerID NOT Groep." + ID;
            SqlCommand cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Gebruiker gebruiker = new Gebruiker();
                    gebruikers.Add(gebruiker);
                }
            }
            conn.Close();
            return gebruikers;
        }
    }
}
