namespace Game.UI.Renderers
{
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultHelpDisplayRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
            Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine();
			outputProvider.DisplayLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}