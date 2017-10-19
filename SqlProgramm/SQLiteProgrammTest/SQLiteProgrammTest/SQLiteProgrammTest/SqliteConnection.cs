using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace SQLiteProgrammTest
{



    class SqliteConnection
    {/// <summary>
     /// Класс работы с SQLite
     /// Метод CreateSqliteBase() создает базу Sqlit если она не создана и таблицу TelegramBotUsers
     /// Метод CheckUsers проверяет есть ли ChatId пользователя в разрешенной базе
     /// </summary>

        public string connString = "Data Source=TelegramBotUsers.db; Version=3;";


        public void CreateSqliteBase()
        {
            if (!System.IO.File.Exists("TelegramBotUsers.db"))
            {
                SQLiteConnection.CreateFile("TelegramBotUsers.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=TelegramBotUsers.db; Version=3;"))
                {
                    try { conn.Open(); }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    SQLiteCommand cmd = conn.CreateCommand();
                    string sql_command = "CREATE TABLE ConfirmedUsers("
                                        + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                                        + "User_ChatID INTEGER, "
                                        + "User_name TEXT);";

                    /*  код и з примера, на всякий случай...

                      + "INSERT INTO ConfirmedUsers(first_name, last_name, sex, birth_date) "
                      + "VALUES ('John', 'Doe', 0, strftime('%s', '1979-12-10'));"
                      + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                      + "VALUES ('Vanessa', 'Maison', 1, strftime('%s', '1977-12-10'));"
                      + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                      + "VALUES ('Ivan', 'Vasiliev', 0, strftime('%s', '1987-01-06'));"
                      + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                      + "VALUES ('Kevin', 'Drago', 0, strftime('%s', '1991-06-11'));"
                      + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                      + "VALUES ('Angel', 'Vasco', 1, strftime('%s', '1987-10-09'));";
                     */
                    cmd.CommandText = sql_command;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else {
                Console.WriteLine("TelegramBotUsers.db существует");
            }
        }
        public void CheckUsers(int ChatId)
        {

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=TelegramBotUsers.db; Version=3;"))
            {
                try { conn.Open(); }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                SQLiteCommand cmd = conn.CreateCommand();

                string sql_command = "SELECT User_ChatID FROM ConfirmedUsers WHERE User_ChatID ='" + ChatId + "'";
                cmd.CommandText = sql_command;
                try
                {
                    SQLiteDataReader r = cmd.ExecuteReader();
                    string line = String.Empty;
                    while (r.Read())
                    {
                        line = r["id"].ToString() + ", "
                             + r["User_ChatID"] + ", "
                             + r["User_name"];

                        Console.WriteLine(line);
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public void SetUserChatID(int ChatId)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=TelegramBotUsers.db; Version=3;"))
            {
                try { conn.Open(); }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                SQLiteCommand cmd = conn.CreateCommand();

                string sql_command = "INSERT INTO 'ConfirmedUsers' (`User_ChatID`, `User_name`,) "
                      + "VALUES ('" + ChatId + "', 'UserXXX')";
                cmd.CommandText = sql_command;


            }


        }

        //пытался переделать ---------------
        //public void SqliteCmd(string cmdStr)
        //{
        //    SQLiteConnection sqliteConnect = new SqliteConnection(connString);
        //    sqliteConnect.Open();
        //    Console.WriteLine(sqliteConnect.State);
        //    Console.WriteLine(sqliteConnect.Database);

        //    SQLiteConnection cmd = new SQLiteConnection();
        //    cmd.Connection = sqliteConnect;
        //    cmd.CommandText = cmdStr;

        //    int number = cmd.ExecuteNonQuery();
        //    Console.WriteLine("Добавлено объектов: {0}", number);

        //    sqlConnect.Close();
        //    Console.WriteLine(sqlConnect.State);
        //}

        // переделываю 
        // создать бд, заполнить бд, вывести результат.
        //-----------------
        public void CreateInsertViewSQLiteDB() //общий метод, доваления выборки из БД, разбить на несколько методов.
        {
            int ChatId = 666666;//477
            if (!System.IO.File.Exists("TelegramBotUsers.db")) SQLiteConnection.CreateFile("TelegramBotUsers.db");


            SQLiteConnection connection = new SQLiteConnection("Data Source = TelegramBotUsers.db; Version = 3;");
            connection.Open();

            //string sqlCmd = "CREATE TABLE IF NOT EXISTS telegram_bot_users (id INTEGER PRIMARY KEY AUTOINCREMENT,login STRING, chat_id INT )";
            //string sqlCmdInsert = "INSERT INTO `telegram_bot_users` (`login`, `chat_id`) VALUES ('UserXX1','12345')";

            //*новый запрос, но нужно проверить string sqlCmdSelect = "SELECT COUNT (*) FROM `telegram_bot_users` WHERE Chat_id = '" + ChatId + "'";
            string sqlCmdSelect = "SELECT Chat_id FROM `telegram_bot_users` WHERE Chat_id = '" + ChatId + "'";
            SQLiteCommand command = new SQLiteCommand(connection);

            //command.CommandText = sqlCmd;
            //command.ExecuteNonQuery();

            //command.CommandText = sqlCmdInsert;
            //command.ExecuteNonQuery();

            //закоменчен код вывода результата SELECT
            //command.CommandText = sqlCmdSelect;
            //SQLiteDataReader reader = command.ExecuteReader();
            //string line = String.Empty;
            //while (reader.Read())
            //{
            //    line = reader["Chat_id"].ToString();

            //    Console.WriteLine(line);
            //}


            // Код для анализа выводимого результата после SELECT запроса
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine(reader.Read());
                Console.WriteLine("Есть в локальной базе");
            }
            else { Console.WriteLine("Нету в локальной базе"); }

            //reader.Close();
            connection.Close();



        }


    }
}
