using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    internal class GameEngine : GameStrategy
    {

        private MoveGameNumber moveNumber;

        public GameEngine(IPlayable gameInstance)
        {
            this.moveNumber = new MoveGameNumber(gameInstance);
         
        }

        public override void Start()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public override void Restart()
        {
            GameFifteen.RestartGame();
        }

        public override void Top()
        {
            GameFifteen.PrintTopHighScore();
        }

        public override void Exit()
        {
            Console.WriteLine("Good bye!");
            GameFifteen.Repeat = false;
            GameFifteen.UserExit = true;
        }

        public override void SaveHighScores()
        {
            // TODO: Implement this method
            // Sava high scores to the file
            throw new NotImplementedException();
        }

        public override void LoadHighScores()
        {
            // TODO: Implement this method
            // Load high scores from the file
            throw new NotImplementedException();
        }

        public override void MoveNumber(int number)
        {
            if (number >= 1 && number <= 15)
            {
                moveNumber.Move(number);
                GameFifteen.PrintTable();
            }
            else
            {
                Console.WriteLine("Illegal move!");
            }
        }
    }
}
