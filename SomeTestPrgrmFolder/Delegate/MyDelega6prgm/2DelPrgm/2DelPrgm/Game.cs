
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    public class Game
    {


        public void StartGame()
        {
            ChouseGameMode();
            CreateGameMap();
        }

        private void ChouseGameMode()
        {
           //TODO: Реализовать выбор игрового режима : мультиплеер или синглплеер. Из енума

            throw new NotImplementedException();
        }

        private void CreateGameMap()
        {
            BattlefieldGenerator bf = new BattlefieldGenerator();
            bf.InitializeField();
        }



    }
}