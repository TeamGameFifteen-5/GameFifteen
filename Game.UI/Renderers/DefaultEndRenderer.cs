namespace Game.UI.Renderers
{
	using Game.Common.Players;
	using Game.UI.IOProviders;

	public class DefaultEndRenderer<TOutputProvider> : IRenderer<TOutputProvider, IPlayer>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider, IPlayer player)
		{
			outputProvider.DisplayLine("Congratulations! You won the game in {0} moves.", player.Score.ToString());
		}
	}
}