using Game.Common.Players;
using System.Collections.Generic;
using System.Linq;

namespace Game.Common.Stats
{
	public sealed class HighScores : IHighScores
	{
		private const int MAX_TOP_PLAYERS = 5;
		private static readonly IHighScores instance = new HighScores();

		private List<IPlayer> highScores;

		private HighScores()
		{
			this.highScores = new List<IPlayer>(MAX_TOP_PLAYERS);
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
			return highScores;
		}

		public void Save(IPlayer player)
		{
			if (highScores.Count < MAX_TOP_PLAYERS)
			{
				highScores.Add(new Player(player));
			}
			else
			{
				foreach (var person in highScores)
				{
					if (player.Score <= person.Score)
					{
						highScores.Remove(highScores[MAX_TOP_PLAYERS - 1]);
						highScores.Add(new Player(player));
						break;
					}
				}
			}

			highScores = highScores.OrderBy(x => x.Score).ToList();
		}
	}
}