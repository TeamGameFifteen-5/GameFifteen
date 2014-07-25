namespace Game.Common.Players
{
    using System;

    [Serializable]

    public class Player : IPlayer, IComparable<IPlayer>
    {

        public Player()
        {

        }

        public Player(IPlayer player)
        {
            this.Name = player.Name;
            this.Score = player.Score;
        }

        public string Name { get; set; }

        public int Score { get; set; }

        public int CompareTo(IPlayer player)
        {
            return (this.Score < player.Score) ? -1 : (this.Score > player.Score) ? 1 : 0;
        }
    }
}