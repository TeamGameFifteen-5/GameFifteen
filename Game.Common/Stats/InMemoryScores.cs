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
			if (this.Stats.Count < MAX_TOP_PLAYERS)
			{
				this.Stats.Add(score);
			}
			else
			{
				foreach (var personScore in this.Stats)
				{
					if (score.ValueObject <= personScore.ValueObject)
					{
						this.Stats.Remove(this.Stats[MAX_TOP_PLAYERS - 1]);
						this.Stats.Add(score);
						break;
					}
				}
			}

			this.Sort<int>(x => x.ValueObject);
		}
	}
}