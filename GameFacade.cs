using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameFacade
    {
        private GameStrategy strategy;
        private MoveGameNumber moveNumber;
        public GameFacade(IPlayable gameInstance)
        {
            strategy = new GameStrategy();
            moveNumber = new MoveGameNumber(gameInstance);
        }

        public void Move(int number)
        {
            moveNumber.Move(number);
        }
    }
}
