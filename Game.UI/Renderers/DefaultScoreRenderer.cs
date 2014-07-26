namespace Game.UI.Renderers
{
	using Game.Common.Stats;
	using Game.UI.IOProviders;
	using System;

	public class DefaultScoreRenderer<TOutputProvider> : IRenderer<TOutputProvider, IStatsStorage>
		where TOutputProvider : IOutputProvider
	{
		#region Constants

		private const string UP_DOWN_TABLE_FRAME = "-------------------------";

		#endregion Constants

		public void Render(TOutputProvider outputProvider, IStatsStorage stats)
		{
			var playerScores = stats.Load();

			outputProvider.DisplayLine("{0}{1}", Environment.NewLine, UP_DOWN_TABLE_FRAME);

			foreach (var playerScore in playerScores)
			{
				outputProvider.DisplayLine("{0}: {1}", playerScore.Name, playerScore.Value);
			}

			outputProvider.DisplayLine("{0}{1}", UP_DOWN_TABLE_FRAME, Environment.NewLine);
		}
	}
}