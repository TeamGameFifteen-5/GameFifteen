namespace Game.Common.CustomEvents
{
	using Game.Common.Stats;

	public class ShowScoreEvent : CustomEvent<IIntegerStats>
	{
		public ShowScoreEvent(IIntegerStats playerScores)
			: base(playerScores)
		{
		}
	}
}