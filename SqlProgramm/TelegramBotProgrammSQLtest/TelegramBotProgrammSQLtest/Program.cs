using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;
using TelegramBotSql;


namespace TelegramBotProgrammSQLtest
{
    class Program
    {
        static void Main(string[] args)
             {
                SqlMethod mDataBase = new SqlMethod();
                // mDataBase.OpenConnectSqlBase(); //подключаемся к базе данных MySql (тествыйЮ данную функцию нужно реализовывать в методе где запрос, так как он не наследуемый.)
                // mDataBase.CloseConnectSqlBase();// отключаемся от бд MySql
                mDataBase.SqlCmd("SELECT name FROM glpi_tickets WHERE id = 1");// запрос селект "SELECT 'name' FROM 'glpi_tickets' WHERE 'id' = 1"
                mDataBase.SqlCmd("SELECT content FROM glpi_tickets WHERE id = 1");
                Console.ReadKey();
             }
            
            
        
    }
}
