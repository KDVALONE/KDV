using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.SqlClient;

namespace TelegramBotSql
{
    
    class SqlMethod
    {
       
        string connString = "datasource=127.0.0.1;port=3306;charset= utf8;database=glpi_db;username=root;password=;pooling=true;";
        //"Server=127.0.0.1;" + "Database=glpi_db;" + "Uid=root;" + "Pwd=;"
        //"server=192.168.104.12;user=tech1;database=tpc2;port=3306;password=Y-96mnrSw;Allow Zero Datetime=true";
        //"server=localhost;user=root;database=glpi_db;port=3306;password=;"

        //public void OpenConnectSqlBase()
        //{
        //    using (MySqlConnection sqlConnect = new MySqlConnection(connString))
        //    {
        //        try
        //        {
        //            sqlConnect.Open();
        //            Console.WriteLine(sqlConnect.State);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            Console.ReadKey();
        //        }
        //    }
        //}

        //public void CloseConnectSqlBase()
        //{
        //    using (MySqlConnection sqlConnect = new MySqlConnection(connString))
        //    {
        //        try
        //        {
        //            sqlConnect.Close();
        //            Console.WriteLine(sqlConnect.State);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            Console.ReadKey();
        //        }
        //    }
        //}
    
        
        public void SqlCmd(string cmdStr)
        {
                MySqlConnection sqlConnect = new MySqlConnection(connString);
                sqlConnect.Open();
                Console.WriteLine(sqlConnect.State);
                Console.WriteLine(sqlConnect.Database);

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandText = cmdStr;
           
         
           // int number = cmd.ExecuteNonQuery();   //выводят кол-во измененныйх или добавленных строк
           //Console.WriteLine("Добавлено объектов: {0}", number);

            //Код для вывода значения поля name  из SELECT запроса
            MySqlDataReader reader = cmd.ExecuteReader();                           

            if (reader.Read())
            {
                string line = string.Empty;
                line = reader["password"].ToString();

                Console.WriteLine("Вывод значения запроса: " + line);
            }
            else { Console.WriteLine("В таблице нет значения"); }
            //(конец)Код для вывода значения поля   из SELECT запроса 

            sqlConnect.Close();
            Console.WriteLine(sqlConnect.State);
        }

    }
}
        
