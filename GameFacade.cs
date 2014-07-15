using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameFacade
    {
        public GameStrategy strategy;
        public GameFacade()
        {
           strategy = new GameStrategy();
        }
    }
}
