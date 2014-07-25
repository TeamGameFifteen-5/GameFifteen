using System.Collections.Generic;

namespace Game.Common.Stats
{
	/// <summary>
	/// Interface for stats storage.
	/// </summary>
	/// <typeparam name="TNameValue">Type of the stats.</typeparam>
	public interface IStatsStorage<TNameValue>
		where TNameValue : INameValue
	{
		/// <summary>
		/// Gets the load.
		/// </summary>
		/// <returns>
		/// The loaded stats.
		/// </returns>
		IEnumerable<TNameValue> Load();

		/// <summary>
		/// Saves the given stats.
		/// </summary>
		/// <param name="stats">The stats to save.</param>
		void Save(TNameValue stats);
	}
}