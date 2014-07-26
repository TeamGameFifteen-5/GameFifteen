namespace Game.UI.Windows.Forms.Renderers
{
	using Game.UI.IOProviders;
	using Game.UI.Renderers;
	using System.Windows.Forms;

	public class ExitWindowRenderer<TIOProvider> : DefaultExitRenderer<TIOProvider>
		where TIOProvider : IIOProvider
	{
		public override void Render(TIOProvider ioProvider)
		{
			base.Render(ioProvider);
			ioProvider.DisplayLine("Press any key to exit . .");
			ioProvider.GetKeyInput();
			Application.Exit();
		}
	}
}