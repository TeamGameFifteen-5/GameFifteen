namespace Game.Common.Stats
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public abstract class StatsStorage<TNameValue> : IStatsStorage<TNameValue>
		where TNameValue : INameValue
	{
		public StatsStorage(int capacity)
		{
			this.Stats = new List<TNameValue>(capacity);
		}

		protected IList<TNameValue> Stats { get; set; }

		public virtual IEnumerable<TNameValue> LoadTyped()
		{
			return this.Stats;
		}

		IEnumerable<INameValue> IStatsStorage.Load()
		{
			return (IEnumerable<INameValue>)this.Stats;
		}

		public abstract void Save(TNameValue stats);

		public virtual void Sort<TCondition>(Func<TNameValue, TCondition> expression)
		{
			this.Stats = this.Stats.OrderBy(expression).ToList();
		}
	}
}