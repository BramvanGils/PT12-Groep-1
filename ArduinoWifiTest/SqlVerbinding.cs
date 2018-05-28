using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ArduinoWifiTest
{
    class SqlVerbinding
    {
        //Fields

        //Constructor
        public SqlVerbinding(string DatabasePad)
        {
            VerbindingString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DatabasePad + ";Integrated Security=True";
            SQL = new SqlConnection(VerbindingString);
            SQL.Open();
            SQL.Close();
        }

        //Properties
        public string VerbindingString { get; private set; }
        public SqlConnection SQL { get; private set; }

        //Methods
        public void Close()
        {
            SQL.Close();
        }
        public List<string> Query(string Command)
        {
            SqlCommand cmd = new SqlCommand(Command, SQL);
            SQL.Open();
            List<string> ReturnData = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int Index = 0;
                while (reader.Read())
                {
                    string NaamKolom = "";
                    if (Index == 0)
                    {
                        for (int u = 0; u < reader.FieldCount; u++)
                        {
                            var Naam = reader.GetName(u);
                            if (u != reader.FieldCount - 1)
                            {
                                NaamKolom += Convert.ToString(Naam) + " - ";
                            }
                            else
                            {
                                NaamKolom += Convert.ToString(Naam);
                            }
                        }
                        ReturnData.Add(NaamKolom);
                    }
                    string DataKolom = "";
                    for (int y = 0; y < reader.FieldCount; y++)
                    {
                        var Data = reader[y].ToString();
                        if (y != reader.FieldCount - 1)
                        {
                            DataKolom += Data + " - ";
                        }
                        else
                        {
                            DataKolom += Data;
                        }
                    }
                    ReturnData.Add(DataKolom);
                    Index++;
                }
            }
            SQL.Close();
            return ReturnData;
        }

    }
}
