namespace Game.Common.Stats
{
	public sealed class InMemoryScores : StatsStorage<INameValue<int>>, IIntegerStats
	{
		private const int MAX_TOP_PLAYERS = 5;
		private static readonly IIntegerStats _Instance = new InMemoryScores();

		private InMemoryScores()
			: base(MAX_TOP_PLAYERS)
		{
		}

		public static IIntegerStats Instance
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

			this.Sort<int>(x => x.ValueObject);
		}
	}
}