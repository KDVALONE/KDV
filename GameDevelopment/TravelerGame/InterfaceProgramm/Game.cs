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
     public Hero hero; 
     public Difficults GameDifficult;
     public int CityCount { get; private set; }

     public Game()
        {
            GameDifficult = GameService.SetGameDifficult();
            CityCount = GameService.GetCityCount(GameDifficult);
        }

        public void PlayerCreate()
        {  HeroCreate heroCreate = new HeroCreate();
           hero = new Hero (heroCreate.CreatePlayerName());
        }

    }
}
