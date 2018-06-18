using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{/// <summary>
 /// Класс игры, отвечающий за глобальную логику игры.
 /// </summary>
    public sealed class Game
    {
        private Hero hero;
        private List<City> citysList = new List<City>();

        public Difficults GameDifficult;
        public int CityCount { get; private set; }
        public List<City> CitysList { get => citysList; set => citysList = value; }
        public Hero Hero { get => hero; set => hero = value; }

        public Game()
        {
            GameDifficult = GameService.SetGameDifficult();
            CityCount = GameService.GetCityCount(GameDifficult);
        }

        public void PlayerCreate()
        {  HeroCreate heroCreate = new HeroCreate();
           Hero = heroCreate.CreatePlayer();
        }
        public void CreateCityes()
        {
            CitysList = CityGenerator.GenerateCity(CityCount);
        }
    }
}
