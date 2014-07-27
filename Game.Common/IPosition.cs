namespace Game.Common
{
	/// <summary>
	/// Interface for position.
	/// </summary>
	public interface IPosition : IClonable<IPosition>
	{
		/// <summary>
		/// Gets the x coordinate.
		/// </summary>
		/// <value>
		/// The x coordinate.
		/// </value>
		int X { get; set; }

		/// <summary>
		/// Gets the y coordinate.
		/// </summary>
		/// <value>
		/// The y coordinate.
		/// </value>
		int Y { get; set; }
	}
}