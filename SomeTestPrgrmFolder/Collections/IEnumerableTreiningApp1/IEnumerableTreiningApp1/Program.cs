using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableTreiningApp1
{
    /// <summary>
    /// Тренировочное приложение для реализции IEnumerable, для перебора класса в собственной коллекции
    /// Вообще, IEnumerable реализуют для перебора все обобщеные готовые коллекции, не совсем понимаю зачем самопалить. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
         Garage garage1 = new Garage();
         
         foreach (Car e in garage1)
         {
             Console.WriteLine($"{e.Name} {e.Speed} {e.Made}");
         }

         Console.ReadKey();
        }
    }
}

//Моя коллекция
public class Garage : IEnumerable
{
    ///Чтоб не реализовывать в ручную все методы IEnumerable проще скрытно использовать обобщеную коллекцию 
    private List<Car> cars = new List<Car>();

 
    public Garage()
    {
        cars.Add(  new Car { Name = "Rocket", Speed = 220, Made = "BMW" });
        cars.Add(  new Car { Name = "Gear", Speed = 200, Made = "BMW" });
        cars.Add(  new Car { Name = "Lucky", Speed = 180, Made = "Lada"});
    }
 
    ///Явная реализация позволяет скрыть метод GetEnumerator от пользователей класса, но для Foreach он будет виден и использоваться
    /// для того чтоб пройтись Foreach по обьекту Garage
    IEnumerator IEnumerable.GetEnumerator()
    {
        return cars.GetEnumerator();
    }
}
public class Car 
{
    
    public string Name;
    public int Speed;
    public string Made;

   
}
