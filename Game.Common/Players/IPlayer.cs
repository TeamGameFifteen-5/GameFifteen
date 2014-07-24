namespace Game.Common.Players
{
	/// <summary>
	/// Interface for player.
	/// </summary>
	public interface IPlayer
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		/// <value>
		/// The score.
		/// </value>
		int Score { get; set; }
	}
}