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
using System.Security.Cryptography;
using BlowFishCS;


namespace TelegramBotProgrammSQLtest
{
    class Program
    {
        static void Main(string[] args)
             {
                SqlMethod mDataBase = new SqlMethod();
            // mDataBase.OpenConnectSqlBase(); //подключаемся к базе данных MySql (тествыйЮ данную функцию нужно реализовывать в методе где запрос, так как он не наследуемый.)
            // mDataBase.CloseConnectSqlBase();// отключаемся от бд MySql
            //mDataBase.SqlCmd("SELECT name FROM glpi_tickets WHERE id = '1'");// запрос селект "SELECT 'name' FROM 'glpi_tickets' WHERE 'id' = 1"
            //mDataBase.SqlCmd("SELECT content FROM glpi_tickets WHERE id = 1");

            //не работает mDataBase.SqlCmd("INSERT INTO glpi_tickets (id, entities_id, name,) VALUES (2, 1, 'Заголовок тестовой заявки через SQL запрос' ");//"INSERT INTO glpi_tickets (id, entities_id, name, date, closedate, solvedate, date_mode, users_id_lustupdater, status, users_id_recipient, reqesttypes_id, content, urgency) VALUES (2, 0, 'Заголовок тестовой заявки через SQL запрос', '2015-09-14 21:41:00',,,2015-09-14 21:41:00,2,2,2,1,'Описание тестовой заявки внесеной через SQL',4 "

            // mDataBase.SqlCmd("INSERT INTO `glpi_tickets` (`name`) VALUES ('test SQL note')"); Добавление записи. Важно чтоб кавычки столбца были косые(где тильда),а где значение одинарные, прямые
            // mDataBase.SqlCmd("UPDATE `glpi_tickets` SET content='описание заявки заданной через SQL', users_id_lastupdater='2', users_id_recipient='2' , status='2' WHERE name='test SQL note'");//Обновление записи

            //ниже запрос на проверку пароля...
            //mDataBase.SqlCmd("SELECT password FROM `glpi_users` WHERE id = '2'");

            //Опыты с шифрованием
            Crypt hash = new Crypt();
            string input = "glpi";
            // Console.WriteLine (hash.GetHash(input)) ;
            //  Console.WriteLine(); // возвращает хэш переданной строки
            //hash.GetHash2();
            hash.BlowfishCrypt();//шифрование с использованием BlowFish
            Console.ReadKey(); 
             }
            
            
        
    }
}
