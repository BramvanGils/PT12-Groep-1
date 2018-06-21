using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NeverBoardSoftwareApplicatie
{
    static class DatabaseManager
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Spelers.mdf;Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(connectionString);
        private static List<Gebruiker> gebruikers = new List<Gebruiker>();
        private static List<Groep> groepen = new List<Groep>();
        private static List<Spel> spellen = new List<Spel>();

        static List<Gebruiker> VraagGebruikerID()
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

        static List<Gebruiker> VraagInfoGebruiker(int ID)
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

        public static List<Groep> VraagGroepID()
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

        public static void MaakNieuweGroepAan(string Naamwaarde)
        {

            conn.Open();
            string Query = "INSERT INTO Groepsnaam VALUES " + Naamwaarde;
            SqlCommand cmd = new SqlCommand(Query, conn);
            conn.Close();
        }

        static List<Groep> VraagInfoGroep(int ID)
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

        static List<Spel> FilterGenre(string genre)
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

        static List<Gebruiker> VraagGebruikersVanGroep(int ID)
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

        static List<Gebruiker> VraagGebruikersNietVanGroep(int ID)
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
    }
}
