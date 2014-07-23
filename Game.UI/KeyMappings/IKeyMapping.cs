using Game.Common;

namespace Game.UI.KeyMappings
{
	/// <summary>
	/// Interface for key mapping.
	/// </summary>
	/// <typeparam name="TKey">Type of the key.</typeparam>
	public interface IKeyMapping<TKey>
	{
		/// <summary>
		/// Maps the given key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// The mapped ActionType of the key.
		/// </returns>
		ActionType Map(TKey key);
	}
}