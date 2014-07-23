namespace Game.Core.Stats
{
	/// <summary>
	/// Interface for stats storage.
	/// </summary>
	/// <typeparam name="TStats">Type of the stats.</typeparam>
	internal interface IStatsStorage<TStats>
	{
		/// <summary>
		/// Gets the load.
		/// </summary>
		/// <returns>
		/// The loaded stats.
		/// </returns>
		TStats Load();

		/// <summary>
		/// Saves the given stats.
		/// </summary>
		/// <param name="stats">The stats to save.</param>
		void Save(TStats stats);
	}
}