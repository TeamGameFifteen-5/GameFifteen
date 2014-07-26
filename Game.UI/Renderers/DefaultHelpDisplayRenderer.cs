namespace Game.UI.Renderers
{
	public class DefaultHelpDisplayRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}