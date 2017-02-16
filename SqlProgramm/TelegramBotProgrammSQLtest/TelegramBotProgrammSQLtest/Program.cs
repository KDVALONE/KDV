using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace TelegramBotProgrammSQLtest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;";
            //"Server=127.0.0.1;" + "Database=glpi_db;" + "Uid=root;" + "Pwd=;"
            //"server=192.168.104.12;user=tech1;database=tpc2;port=3306;password=Y-96mnrSw;Allow Zero Datetime=true";
            //"server=localhost;user=root;database=glpi_db;port=3306;password=;";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            { Console.WriteLine("Connect to DB.."); sqlConnection.Open(); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            Console.WriteLine("Close connect...");
            sqlConnection.Close();
            

        }
    }
}
