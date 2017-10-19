using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BlowFishCS;

namespace TelegramBotProgrammSQLtest
{
    class Crypt
    {
        //Код сравнения и вывода хэша пароля (взял с сайта)--- нач---
        public static MD5 md5 = MD5.Create();
        // Функция возвращает хэш переданной строки.
        public  string GetHash(string input)
        {
          
            var data = Encoding.Default.GetBytes(input);
            data = md5.ComputeHash(data);
            var result = new StringBuilder();

            foreach (var b in data)
                result.Append(b.ToString("x2"));

            return result.ToString();
        }
        public void  GetHash2()
        {
            string input = "glpi";
            var data = Encoding.Default.GetBytes(input);
            data = md5.ComputeHash(data);
            var result = new StringBuilder();

            foreach (var b in data)
                result.Append(b.ToString("x2"));

            Console.WriteLine(result.ToString());
            
        }

        //// Функция сравнивает переданные строку и хэш.
        //public static bool CompareWithHash(string input, string hash)
        //{
        //    var inputHash = GetHash(input);
        //    return inputHash.Equals(hash, StringComparison.InvariantCultureIgnoreCase);
        //}

        /// Ниже вставлен кода для шифрования по BLOWFISH, код из инета
        public void BlowfishCrypt()
        {
        BlowFish bf = new BlowFish("04B915BA43FEB5B6");
        string  textToCipher = "glpi";
        string cipherText = "";
            cipherText = bf.Encrypt_CBC(textToCipher);

            //using (FileStream fs = File.OpenRead(textBox1.Text))
            //{

            //            byte[] b = new byte[1024];
            //UTF8Encoding temp = new UTF8Encoding(true);
            //            while (textToCipher.Read(b, 0, b.Length) > 0)
            //            {
            //                cipherText = bf.Encrypt_CBC(temp.GetString(b));
            //            }
            //        //}
            Console.WriteLine(cipherText);
 
            string plainText = bf.Decrypt_CBC(cipherText);
            Console.WriteLine(plainText);
            Console.ReadKey();
        }
        //BlowFish конец

    }

    //Клд сравнения и вывода хэша пароля (взял с сайта)--- конец--
}

