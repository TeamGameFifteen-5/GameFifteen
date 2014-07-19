namespace GameFifteen
{
    public abstract class GameStrategy
    {
        public abstract void Start();

        public abstract void Restart();

        public abstract void Top();

        public abstract void Exit();

        public abstract void SaveHighScores();

        public abstract void LoadHighScores();

        public abstract void MoveNumber(int number);
    }
}
