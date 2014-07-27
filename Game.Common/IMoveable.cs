namespace Game.Common
{
	/// <summary>
	/// Interface for moveable.
	/// </summary>
	public interface IMoveable
	{
		/// <summary>
		/// Moves the given direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns>
		/// true if it succeeds, false if it fails.
		/// </returns>
		bool Move(Direction direction);
	}
}