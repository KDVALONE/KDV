using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramGlpiBot
{
    class TelegramBotSqlCommand
    {
        /// <summary>
        /// Базовый класс для обращения
        /// TODO:
        /// подготовить для наследования от него 
        /// </summary>

        string ConnString { get; set; }

        public TelegramBotSqlCommand()
        {
            ConnString = Settings.Default.ConnectionString;
        }

        virtual public void ExecuteSqlCommand(string cmdStr)
        {
        MySqlConnection sqlConnect = new MySqlConnection(ConnString);
        sqlConnect.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = sqlConnect;
        cmd.CommandText = cmdStr;
        
        }

    }
}
