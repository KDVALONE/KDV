using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramGlpiBot
{
    class SqlMethod
    { /// <summary>
    /// Класс для подключения к glpi_db и исполнению команд
    /// 
    /// </summary>
       
            string ConnString { get; set; }

          public  SqlMethod()
            {
                ConnString = Settings.Default.ConnectionString;
            }


            public void GetTickets(string cmdStr)
            {
            //TODO:
            //переписать в соответствии с ООП
            //изменить reader.Read поместив данные в массив или список
            // переписать входящий запрос на используя обращение к нескольким таблицам
                MySqlConnection sqlConnect = new MySqlConnection(ConnString);
                sqlConnect.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string name = string.Empty;
                string content = string.Empty;
                string status = string.Empty;
                string location = string.Empty;
                 name = reader["name"].ToString();
                 content = reader["content"].ToString();
                 status = reader["status"].ToString();
                 location = reader["location_id"].ToString();

                Console.WriteLine("Вывод значения запроса: " + name);
            }

        }
        

    }
}
