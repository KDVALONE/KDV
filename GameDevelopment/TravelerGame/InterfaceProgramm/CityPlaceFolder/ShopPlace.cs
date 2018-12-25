using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{   [MainPlace]
    public sealed class ShopPlace : CityPlace
    {

        public ShopPlace(City city)
        {
            CityPlaceType = CityPlaceTypes.shop;
            CurrentCity = city;
            Dictionary<string, string> cityPlaceDescDictonary = CityPlaceDescGenerator.GetCityPlaceDesc(CityPlaceType, CurrentCity.CityType);
            CityPlaceDescription = cityPlaceDescDictonary.ElementAt(0).Value;
        }
    }
}