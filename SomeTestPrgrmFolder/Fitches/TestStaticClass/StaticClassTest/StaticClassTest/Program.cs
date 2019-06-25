using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassTest
{

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Dictionary<string, string> ListBuilding = new Dictionary<string, string>();

            ListBuilding = StatClass.GetRightDescription((CityTypes)random.Next(Enum.GetValues(typeof(CityTypes)).Length), (CityPlaceTypes)random.Next(Enum.GetValues(typeof(CityPlaceTypes)).Length));
            Console.WriteLine($"Название учреждения:{ListBuilding.ElementAt(0).Key} Местность: {ListBuilding.ElementAt(0).Value}");
            ListBuilding = StatClass.GetRightDescription((CityTypes)random.Next(Enum.GetValues(typeof(CityTypes)).Length), (CityPlaceTypes)random.Next(Enum.GetValues(typeof(CityPlaceTypes)).Length));
            Console.WriteLine($"Название учреждения:{ListBuilding.ElementAt(0).Key} Местность: {ListBuilding.ElementAt(0).Value}");

            ListBuilding = StatClass.GetRightDescription((CityTypes)random.Next(Enum.GetValues(typeof(CityTypes)).Length), (CityPlaceTypes)random.Next(Enum.GetValues(typeof(CityPlaceTypes)).Length));
            Console.WriteLine($"Название учреждения:{ListBuilding.ElementAt(0).Key} Местность: {ListBuilding.ElementAt(0).Value}");
            ListBuilding = StatClass.GetRightDescription((CityTypes)random.Next(Enum.GetValues(typeof(CityTypes)).Length), (CityPlaceTypes)random.Next(Enum.GetValues(typeof(CityPlaceTypes)).Length));
            Console.WriteLine($"Название учреждения:{ListBuilding.ElementAt(0).Key} Местность: {ListBuilding.ElementAt(0).Value}");
            ListBuilding = StatClass.GetRightDescription((CityTypes)random.Next(Enum.GetValues(typeof(CityTypes)).Length), (CityPlaceTypes)random.Next(Enum.GetValues(typeof(CityPlaceTypes)).Length));
            Console.WriteLine($"Название учреждения:{ListBuilding.ElementAt(0).Key} Местность: {ListBuilding.ElementAt(0).Value}");


            
            Console.ReadKey();
        }
    }



    public enum CityTypes { City, town, }
    public enum CityPlaceTypes { inn, shop, medCenter }


    public static class StatClass
    {
        static Random rnd = new Random();
       
        static string[] CityInnName { get; set; }
        static string[] TownInnName { get; set; }
        static string[] CityShopName { get; set; }
        static string[] TownShopName { get; set; }
        static string[] CityMedCenterName { get; set; }
        static string[] TownMedCenterName { get; set; }

        static string[] CityName { get; set; }
        static string[] TownName { get; set; }
        static StatClass()
        {
            CityInnName = new string[] { "Гостиница Украина", "Гостиница Россия" };
            TownInnName = new string[] { "Хостел Малинки", "Хостел Теремок" };
            CityShopName = new string[] { "Гипермаркет Ашан", "Гипермаркет Глобус" };
            TownShopName = new string[] { "Продуктовый Изюминка", "Продуктовый Продукты" };
            CityMedCenterName = new string[] { "Федеральная больница Склифасовского", "Федеральная больница Федорова" };
            TownMedCenterName = new string[] { "Городская больница 1", "Городская больница 2" };
            CityName = new string[] { "Мегаполис", "Город" };
            TownName = new string[] { "Поселок", "Деревня" };
        }
        
        public static Dictionary<string, string> GetRightDescription(CityTypes cityType, CityPlaceTypes cityPlaceType)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            switch (cityType)
            {
                case CityTypes.City:
                    {
                        switch (cityPlaceType)
                        {
                            case CityPlaceTypes.inn:
                                dict.Add(CityInnName[rnd.Next(0, CityInnName.Length)], CityName[rnd.Next(0, CityName.Length)]);
                                SomeMethod();
                                break;
                            case CityPlaceTypes.shop:
                                dict.Add(CityShopName[rnd.Next(0, CityShopName.Length)], CityName[rnd.Next(0, CityName.Length)]);
                                break;
                            case CityPlaceTypes.medCenter:
                                dict.Add(CityMedCenterName[rnd.Next(0, CityMedCenterName.Length)], CityName[rnd.Next(0, CityName.Length)]);
                                break;
                        }

                        break;
                    }
                case CityTypes.town:
                    {
                        switch (cityPlaceType)
                        {
                            case CityPlaceTypes.inn:
                               dict.Add(TownInnName[rnd.Next(0, TownInnName.Length)], TownName[rnd.Next(0, TownName.Length)]);
                                  break;
                            case CityPlaceTypes.shop:
                               dict.Add(TownShopName[rnd.Next(0, TownShopName.Length)], TownName[rnd.Next(0, TownName.Length)]);
                                  break;
                            case CityPlaceTypes.medCenter:
                                dict.Add(TownMedCenterName[rnd.Next(0, TownMedCenterName.Length)], TownName[rnd.Next(0, TownName.Length)]);
                                  break;
                         }
                        break;
                    }
                   
            }
            return dict;

        }
        private static void SomeMethod()
        {
            Console.WriteLine("ХААХА!"  );
        }
    }
}