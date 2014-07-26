namespace Game.UI.Windows.Forms.Renderers
{
	using Game.UI.Renderers;
	using Game.UI.Windows.Forms.IOProviders;
	using System.Drawing;
	using System.Windows.Forms;

	public class ChooseDifficultyImageRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IWindowsFormsOutputProvider
	{
		private const string IMAGE_PATH = @"\..\..\Content\ChooseDifficulty.png";

		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
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