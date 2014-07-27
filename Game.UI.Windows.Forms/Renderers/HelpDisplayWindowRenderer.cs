namespace Game.UI.Windows.Forms.Renderers
{
	using Game.Common.Utils;
	using Game.UI.Renderers;
	using Game.UI.Windows.Forms.IOProviders;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;
	using System.Windows.Forms;

	/// <summary>
	/// Help display window renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	/// <seealso cref="TGame.UI.Renderers.IRenderer{TOutputProvider}"/>
	[ExcludeFromCodeCoverage]
	public class HelpDisplayWindowRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IWindowsFormsOutputProvider
	{
		/// <summary>
		/// Full pathname of the image file.
		/// </summary>
		private const string IMAGE_PATH = @"\..\..\Content\Logo.png";

		/// <summary>
		/// Renders help display screen to the given outputProvider.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		public void Render(TOutputProvider outputProvider)
		{
			Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine();
			outputProvider.DrawImage(Image.FromFile(Application.StartupPath + IMAGE_PATH));
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("Please try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}