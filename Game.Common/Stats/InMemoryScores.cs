using System.Collections.Generic;
using System.Linq;

namespace Game.Common.Stats
{
	public sealed class InMemoryScores : StatsStorage<INameValue<int>>, IInMemoryScores
	{
		private const int MAX_TOP_PLAYERS = 5;
		private static readonly InMemoryScores _Instance = new InMemoryScores();

		private InMemoryScores()
			: base(MAX_TOP_PLAYERS)
		{
		}

		public static InMemoryScores Instance
		{
			get
			{
				return _Instance;
			}
		}

		public override void Save(INameValue<int> score)
		{
			if (Stats.Count < MAX_TOP_PLAYERS)
			{
				Stats.Add(score);
			}
			else
			{
				foreach (var personScore in Stats)
				{
					if (score.ValueObject <= personScore.ValueObject)
					{
						Stats.Remove(Stats[MAX_TOP_PLAYERS - 1]);
						Stats.Add(score);
						break;
					}
				}
			}

			Stats = Stats.OrderBy(x => x.ValueObject).ToList();
		}
	}
}