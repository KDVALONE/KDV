using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    /// <summary>
    /// Класс для города. 
    /// Служит для отправным хабом героя. 
    /// Содержит различные здания: Таверна, Мед цетр, Лавка торговца, возможно спец учреждения (притоны бандитов и тд.) зависит от типа города
    /// Города генерируются случайным образом, бывают разных типов Промышленные, простые поселения, торговые хабы, мелкие деревушки
    /// </summary>

    class City
    {
       Random rnd = new Random();
       public CityTypes CityType { get; private set; }
       public Dictionary<string, string> CityDescriptionDict { get; private set; }
       public string CityName { get; private set; }
       public string CityDescription { get; private set; }
       public List<CityPlace> CityPlace { get; private set; }

       public City()
        {
            this.CityType = GameService.GetCityType();

            this.CityDescriptionDict = CityDescriptionGenerator.GetCityDescription(CityType);
            CityName = CityDescriptionDict.ElementAt(0).Key;
            CityDescription = CityDescriptionDict.ElementAt(0).Value;
            CityPlace = //TODO:Сюда сделать Generator для CityPlace на основании типа города,
        }


        


    }
}
