using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLiteProgrammTest
{
    class Program
    {/// <summary>
     /// Тестовая програма, для тренировки работы с SQLite
     /// проверить есть ли SQLite DB
     /// составить таблицу подтвержденных пользователей.
     /// 
     /// </summary>
        public int ChatId { get;set;}

        public Program()
            {
                 ChatId = 123456;
            }

        static void Main()
        {
           // Program p = new Program();
            SqliteConnection sqlconn = new SqliteConnection();
            // sqlconn.CreateSqliteBase();
            // sqlconn.SetUserChatID(p.ChatId);
            // sqlconn.CheckUsers(p.ChatId);
            sqlconn.CreateInsertViewSQLiteDB();
            Console.ReadKey();
        }
    }
}
