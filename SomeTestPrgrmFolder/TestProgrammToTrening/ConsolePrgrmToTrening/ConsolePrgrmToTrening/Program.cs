using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;

namespace TestNameSpace
{

    class Program
    {
        static string ServerAddress = @"Data Source=Dmitriy\SQLEXPRESS;Initial Catalog=BD_SQLGOFF_VALUEFIRST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Main()
        {
            D d = new D();
            d.Go();
            d.Go1();
            d.Go2();
            Console.WriteLine( IsConnectedToInternet(ServerAddress));
            Console.ReadLine();


        }
        public static bool IsConnectedToInternet(string ServerAddress)
        {
            System.Data.SqlClient.SqlConnection sql = new System.Data.SqlClient.SqlConnection();
            sql.ConnectionString = ServerAddress;
            try { sql.Open(); } catch { throw  new Exception("bad"); }
           
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(ServerAddress, 5000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch
            {
                return false;
            }
            //
            return false;
        }
    }





    abstract public class A
    {
        abstract public void Go();
        
    }
    abstract public class B :A
    {
         abstract public void Go1();

    }

    abstract public  class C : B
    {
        string a = "a";
        public override void Go() { Console.WriteLine("ГО"); }
        public override void Go1() { Console.WriteLine("ГО1"); }
       abstract public void Go2();
    }
    public class D : C
    {
        public override void Go2() { Console.WriteLine("Го2"); }

    }

}