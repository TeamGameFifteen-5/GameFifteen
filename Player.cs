namespace GameFifteen
{
    using System;

    public class Player
    {
        private readonly GameFacade gameFacade;
        //TODO: make class Score
        private int score;

        public Player()
        {
            this.gameFacade = new GameFacade(GameSingleton.Instance);
            this.Score = 0;
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            private set
            {
                this.score = value;
            }
        }

        public void GetCommand()
        {
            string command = Console.ReadLine();

            Command commandToExecute = new GameCommand(this.gameFacade, command);
            commandToExecute.Execute();
        }

        public void AddPoint()
        {
            this.score++;
        }

        public void ResetScore()
        {
            this.score = 0;
        }
    }
}
