namespace Game.Common.Stats
{
    using Game.Common.Players;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    public sealed class HighScores : IHighScores
    {
        private const int MaxTopPlayers = 5;
        private const string fileAddress = @"../../GameFifteen.game15";
        private static readonly IHighScores instance = new HighScores();

        private List<IPlayer> highScores;

        private HighScores()
        {
            this.highScores = this.LoadFromFile();

            if (this.highScores == null)
            {
                this.highScores = new List<IPlayer>(MaxTopPlayers);
            }
        }

        public static IHighScores Instance
        {
            get
            {
                return instance;
            }
        }

        public List<IPlayer> Load()
        {
            return this.highScores;
        }

        public void Save(IPlayer player)
        {
            if (this.highScores.Count < MaxTopPlayers)
            {
                this.highScores.Add(new Player(player));
            }
            else
            {
                foreach (var person in highScores)
                {
                    if (player.Score <= person.Score)
                    {
                        this.highScores.Remove(this.highScores[MaxTopPlayers - 1]);
                        this.highScores.Add(new Player(player));
                        break;
                    }
                }
            }

            this.Sort();
            this.SaveInFile();
        }

        public void Sort()
        {
            highScores = highScores.OrderBy(x => x.Score).ToList();
        }

        private void SaveInFile()
        {
            using (Stream file = File.Open(fileAddress, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, this.highScores);
            }
        }

        private List<IPlayer> LoadFromFile()
        {
            Stream stream = null;
            List<IPlayer> highScoresFromFile;
            try
            {
                using (stream = File.Open(fileAddress, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    highScoresFromFile = (List<IPlayer>)formatter.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                return null;
            }

            return highScoresFromFile;
        }
    }
}