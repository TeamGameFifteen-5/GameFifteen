namespace Game.Common.Stats
{
	using System.Collections.Generic;

	public abstract class StatsStorage<TNameValue> : IStatsStorage<TNameValue>
		where TNameValue : INameValue
	{
		public StatsStorage(int capacity)
		{
			this.Stats = new List<TNameValue>(capacity);
		}

		protected IList<TNameValue> Stats { get; set; }

		public virtual IEnumerable<TNameValue> Load()
		{
			return this.Stats;
		}

		public abstract void Save(TNameValue stats);
	}
}