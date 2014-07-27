namespace Game.UI.Windows.Forms.Renderers
{
	using Game.Common.Utils;
	using Game.UI.Renderers;
	using Game.UI.Windows.Forms.IOProviders;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;
	using System.Windows.Forms;

	/// <summary>
	/// Choose difficulty window renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	/// <seealso cref="Game.UI.Renderers.IRenderer{TOutputProvider}"/>
	[ExcludeFromCodeCoverage]
	public class ChooseDifficultyWindowRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IWindowsFormsOutputProvider
	{
		/// <summary>
		/// Full pathname of the image file.
		/// </summary>
		private const string IMAGE_PATH = @"\..\..\Content\ChooseDifficulty.png";

		/// <summary>
		/// Renders choose difficulty screen to the given outputProvider.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		public void Render(TOutputProvider outputProvider)
		{
			Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine();
			outputProvider.DrawImage(Image.FromFile(Application.StartupPath + IMAGE_PATH));
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("1. Easy");
			outputProvider.DisplayLine("2. Normal");
			outputProvider.DisplayLine("3. Hard");
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("[1|2|3]: ");
		}
	}
}