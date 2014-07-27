namespace Game.Common.CustomEvents
{
	using Game.Common.Stats;

	/// <summary>
	/// Represents show score event.
	/// </summary>
	/// <seealso cref="Game.Common.CustomEvents.CustomEvent"/>
	public class ShowScoreEvent : CustomEvent<IIntegerStats>
	{
		/// <summary>
		/// Initializes a new instance of the ShowScoreEvent class.
		/// </summary>
		/// <param name="playerScores">The player scores.</param>
		public ShowScoreEvent(IIntegerStats playerScores)
			: base(playerScores)
		{
		}
	}
}