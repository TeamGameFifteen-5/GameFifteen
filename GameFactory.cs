using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameFactory
    {
        public GameSingleton initGame;
        public GameFacade facade;

        public GameFactory()
        {
            initGame = GameSingleton.Instance;
            facade = new GameFacade();
        }
    }
}
