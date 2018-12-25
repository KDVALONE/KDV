using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TravelerGame
{/// <summary>
/// Класс служит .для генерации специальных мест в городе, в зависимости от типа города.
/// </summary>
    static class CityPlaceGenerator
    {

        public static List<CityPlace> GetCityPlaceList(CityTypes cityType)
        {
            List<CityPlace> cityPlaceList = new List<CityPlace>();
            Type ourtype = typeof(CityPlace);
            Type[] types = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype)).ToArray();
            for (int i = 0; i < types.Length; i++)
            {
                MainPlaceAttribute mainPlace = (MainPlaceAttribute)Attribute.GetCustomAttribute(types[i], typeof(MainPlaceAttribute));
                if (mainPlace != null)
                {
                    cityPlaceList.Add((CityPlace)Activator.CreateInstance(types[i], cityType));
                }
            }
                return cityPlaceList;
        }
    }
}
