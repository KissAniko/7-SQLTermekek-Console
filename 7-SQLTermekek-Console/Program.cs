using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_SQLTermekek_Console
{
    internal class Program
    {       
            static void Main(string[] args)
            {
                string kapcsolatleiro = "datasource=127.0.0.1;port=3306;database=hardver;username=root;password=;";

                MySqlConnection SQLkapcsolat = new MySqlConnection(kapcsolatleiro);
                try
                {
                    SQLkapcsolat.Open();
                }
                catch (MySqlException hiba)
                {
                    Console.WriteLine(hiba.Message);
                    Environment.Exit(1);
                }
               
                // Mennyi a Genius billentyűzeteinek átlagos ára?

                string SQLselect = " SELECT AVG(Ár) as átlagÁr" +
                                   " FROM termékek " +
                                   " WHERE Gyártó ='Genius' " +
                                   " AND kategória = 'billentyűzet' ";

                MySqlCommand SQLparancs2 = new MySqlCommand(SQLselect, SQLkapcsolat);
                MySqlDataReader eredmenyOlvaso = SQLparancs2.ExecuteReader();

                while (eredmenyOlvaso.Read())
                {

                    Console.Write(eredmenyOlvaso.GetString(0) + " - ");
                    string atlagAr = $"{eredmenyOlvaso.GetDouble("átlagÁr"):f2}";
                    Console.WriteLine(atlagAr.PadLeft(15) + "Ft");

                }
                eredmenyOlvaso.Close();
                SQLkapcsolat.Close();


            }
        }
    }


