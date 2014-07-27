namespace Game.Common.Stats
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface for stats storage.
	/// </summary>
	public interface IStatsStorage
	{
		/// <summary>
		/// Gets the stats.
		/// </summary>
		/// <returns>
		/// The loaded stats.
		/// </returns>
		IEnumerable<INameValue> Load();
	}
}