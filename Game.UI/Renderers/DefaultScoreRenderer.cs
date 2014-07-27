namespace Game.UI.Renderers
{
    using Game.Common.Stats;
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultScoreRenderer<TOutputProvider> : IRenderer<TOutputProvider, IStatsStorage>
		where TOutputProvider : IOutputProvider
	{
		#region Constants

		private const string UP_DOWN_TABLE_FRAME = "-------------------------";

		#endregion Constants

		public void Render(TOutputProvider outputProvider, IStatsStorage stats)
		{
            Validation.ThrowIfNull(outputProvider);
            Validation.ThrowIfNull(stats);

			var playerScores = stats.Load();

			outputProvider.DisplayLine(UP_DOWN_TABLE_FRAME);

			foreach (var playerScore in playerScores)
			{
				outputProvider.DisplayLine("{0}: {1}", playerScore.Name, playerScore.Value);
			}

			outputProvider.DisplayLine(UP_DOWN_TABLE_FRAME);
		}
	}
}