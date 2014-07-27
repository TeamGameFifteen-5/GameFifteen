namespace Game.Common.Stats
{
	using Game.Common.Utils;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Stats storage.
	/// </summary>
	/// <typeparam name="TNameValue">Type of the name value.</typeparam>
	/// <seealso cref="Game.Common.Stats.IStatsStorage{TNameValue}"/>
	public abstract class StatsStorage<TNameValue> : IStatsStorage<TNameValue>
		where TNameValue : INameValue
	{
		/// <summary>
		/// The stats.
		/// </summary>
		private IList<TNameValue> _stats;

		/// <summary>
		/// Initializes a new instance of the StatsStorage class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public StatsStorage(int capacity)
		{
			this.Stats = new List<TNameValue>(capacity);
		}

		/// <summary>
		/// Gets or sets the stats.
		/// </summary>
		/// <value>
		/// The stats.
		/// </value>
		protected IList<TNameValue> Stats
		{
			get
			{
				return this._stats;
			}
			set
			{
				Validation.ThrowIfNull(value);
				this._stats = value;
			}
		}

		/// <summary>
		/// Gets the collection.
		/// </summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process load typed in this collection.
		/// </returns>
		public virtual IEnumerable<TNameValue> LoadTyped()
		{
			return this.Stats;
		}

		/// <summary>
		/// Gets the collection.
		/// </summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process load in this collection.
		/// </returns>
		IEnumerable<INameValue> IStatsStorage.Load()
		{
			return (IEnumerable<INameValue>)this.LoadTyped();
		}

		/// <summary>
		/// Saves the given stats.
		/// </summary>
		/// <param name="stats">The stats to save.</param>
		public abstract void Save(TNameValue stats);

		/// <summary>
		/// Sorts the given expression.
		/// </summary>
		/// <typeparam name="TCondition">Type of the condition.</typeparam>
		/// <param name="expression">The expression.</param>
		public virtual void Sort<TCondition>(Func<TNameValue, TCondition> expression)
		{
			Validation.ThrowIfNull(expression);
			this.Stats = this.Stats.OrderBy(expression).ToList();
		}
	}
}