using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public static class CityGenerator
    { 

        public static List<City> GenerateCity(int cityCount)
        {
            List<City> cityList = new List<City>();
            for (int i = 0; i < cityCount; i++)
            {
                cityList.Add( new City());
            }
            return cityList;
        }
    }
}
