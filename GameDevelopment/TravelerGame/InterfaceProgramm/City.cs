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

    public class City
    {
       Random rnd = new Random();
       public CityTypes CityType { get; private set; }
       public Dictionary<string, string> CityDescriptionDict { get; private set; }
       public string CityName { get; private set; }
       public string CityDescription { get; private set; }
       public List<CityPlace> CityPlace { get; private set; }
        public int CityVisitedCount { get; private set; }
       
       public City()
        {
            this.CityType = GameService.GetCityType();

            this.CityDescriptionDict = CityDescriptionGenerator.GetCityDescription(CityType);
            CityName = CityDescriptionDict.ElementAt(0).Key;
            CityDescription = CityDescriptionDict.ElementAt(0).Value;
            CityPlace = CityPlaceGenerator.GetCityPlaceList(CityType);
            CityVisitedCount = 0;
        }

        public void ComeInCityPlace(Hero hero) { }
        public void ExiteCityPlace(Hero hero) { }

        public void ArrivededInCity()
        {
            Console.WriteLine($"Вы приходите в {CityName}./n");
            if (CityVisitedCount == 0)
            { SeeCityDescription(); CityVisitedCount = 1; }
            SelectCityOption();


        }
        private void SeeCityDescription() => Console.WriteLine($"{CityDescription}/n");
        
        public void SelectCityOption()
        {
            
            
        }


        private void SelectCityPlace()
        {
            int cityPlaceNumber = 1;
            int selectOptionNumber ;
            Console.WriteLine("Выбирите куда вы хотите отправиться: ");
            Console.WriteLine("0 В меню поселения");
            foreach (CityPlace e in CityPlace)
            {
                Console.WriteLine($"{cityPlaceNumber} {e.CityPlaceName}");
                cityPlaceNumber++;
            }
            if ((selectOptionNumber = Int32.Parse(Console.ReadLine())) == )
            { } 
            
                
                
            
            

        }


    }
}
