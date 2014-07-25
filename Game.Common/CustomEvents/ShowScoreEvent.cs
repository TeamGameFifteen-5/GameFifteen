namespace Game.Common.CustomEvents
{
	using Game.Common.Stats;

	public class ShowScoreEvent : CustomEvent<IInMemoryScores>
	{
		public ShowScoreEvent(IInMemoryScores playerScores)
			: base(playerScores)
		{
		}
	}
}