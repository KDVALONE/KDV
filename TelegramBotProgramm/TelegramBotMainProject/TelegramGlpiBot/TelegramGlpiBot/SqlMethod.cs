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


            public void SqlCmd(string cmdStr)
            {
                MySqlConnection sqlConnect = new MySqlConnection(ConnString);
                sqlConnect.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;

            }
        

    }
}
