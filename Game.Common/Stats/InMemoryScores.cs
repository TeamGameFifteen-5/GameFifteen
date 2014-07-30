namespace Game.Common.Stats
{
    using Game.Common.Utils;

	/// <summary>
	/// In memory scores.
	/// Implements Singleton Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.Stats.StatsStorage{Game.Common.INameValue{System.Int32}}"/>
	/// <seealso cref="Game.Common.Stats.IIntegerStats"/>
	public sealed class InMemoryScores : StatsStorage<INameValue<int>>, IIntegerStats
	{
		/// <summary>
		/// The maximum top players.
		/// </summary>
		private const int MAX_TOP_PLAYERS = 5;

		/// <summary>
		/// The instance.
		/// </summary>
		private static readonly IIntegerStats _Instance = new InMemoryScores();

		/// <summary>
		/// Prevents a default instance of the InMemoryScores class from being created.
		/// </summary>
		private InMemoryScores()
			: base(MAX_TOP_PLAYERS)
		{
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static IIntegerStats Instance
		{
			get
			{
				return _Instance;
			}
		}

		/// <summary>
		/// Saves the given score.
		/// </summary>
		/// <param name="score">The score to save.</param>
		public override void Save(INameValue<int> score)
		{
			Validation.ThrowIfNull(score);

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