using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramGlpiBot
{
    class TelegramExecuteComand 
    {
        string ConnString { get; set; }

        public TelegramExecuteComand()
        {
            ConnString = Settings.Default.ConnectionString;
        }

        public string ExecsuteSqlCommandSelect(string cmdStr)
        {
            using (MySqlConnection sqlConnect = new MySqlConnection(ConnString))
            {
                MySqlCommand cmd = new MySqlCommand();
                sqlConnect.Open();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string line = string.Empty;
                    line = reader["password"].ToString();

                    Console.WriteLine("Вывод значения запроса: " + line);

                }
                //удалить, возвращать от вет
                string a = "1";
                return a;
            }

        }
        public void ExecsuteSqlCommandInsert(string cmdStr)
        {
            using (MySqlConnection sqlConnect = new MySqlConnection(ConnString))
            {
                MySqlCommand cmd = new MySqlCommand();
                sqlConnect.Open();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;
                cmd.ExecuteNonQuery();
            }

        }
        public void ExecsuteSqlCommandUpdate(string cmdStr)
        {
            using (MySqlConnection sqlConnect = new MySqlConnection(ConnString))
            {
                MySqlCommand cmd = new MySqlCommand();
                sqlConnect.Open();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;
                cmd.ExecuteNonQuery();
            }
        }
        public void ExecsuteSqlCommandDelete(string cmdStr)
        {
            using (MySqlConnection sqlConnect = new MySqlConnection(ConnString))
            {
                MySqlCommand cmd = new MySqlCommand();
                sqlConnect.Open();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;
                cmd.ExecuteNonQuery();
            }
        }

    }
}

