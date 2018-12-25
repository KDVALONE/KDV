using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    [MainPlace]
    public class MedCenterPlace : CityPlace
    {
        public MedCenterPlace(City city)
        {
            CityPlaceType = CityPlaceTypes.medCenter;
            CurrentCity = city;
            Dictionary<string, string> cityPlaceDescDictonary =  CityPlaceDescGenerator.GetCityPlaceDesc(CityPlaceType, CurrentCity.CityType);
            CityPlaceDescription = cityPlaceDescDictonary.ElementAt(0).Value;

        }

    }
}
