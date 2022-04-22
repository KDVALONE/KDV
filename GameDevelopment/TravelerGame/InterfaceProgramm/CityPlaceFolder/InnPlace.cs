
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TravelerGame
{
    [MainPlace]
    public class InnPlace : CityPlace
    {
        public InnPlace(City city)
        {
            CityPlaceType = CityPlaceTypes.inn;
            CurrentCity = city;
            Dictionary<string, string> cityPlaceDescDictonary = CityPlaceDescGenerator.GetCityPlaceDesc(CityPlaceType, CurrentCity.CityType);
            CityPlaceDescription = cityPlaceDescDictonary.ElementAt(0).Value;
            
        }
        
    }
    
}