namespace Game.UI.Windows.Forms.Renderers
{
	using Game.UI.Renderers;
	using Game.UI.Windows.Forms.IOProviders;
	using System.Drawing;
	using System.Windows.Forms;

	public class HelpDisplayImageRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IWindowsFormsOutputProvider
	{
		private const string IMAGE_PATH = @"\..\..\Content\Logo.png";

		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DrawImage(Image.FromFile(Application.StartupPath + IMAGE_PATH));
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("Please try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}