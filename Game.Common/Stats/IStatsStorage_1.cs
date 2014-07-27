namespace Game.Common.Stats
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface for stats storage.
	/// </summary>
	/// <typeparam name="TNameValue">Type of the stats.</typeparam>
	public interface IStatsStorage<TNameValue> : IStatsStorage
		where TNameValue : INameValue
	{
		/// <summary>
		/// Gets the stats.
		/// </summary>
		/// <returns>
		/// The loaded stats.
		/// </returns>
		IEnumerable<TNameValue> LoadTyped();

		/// <summary>
		/// Saves the given stats.
		/// </summary>
		/// <param name="stats">The stats to save.</param>
		void Save(TNameValue stats);
	}
}