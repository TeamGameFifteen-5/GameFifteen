namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public class DefaultStartRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DisplayLine(" ██████╗  █████╗ ███╗   ███╗███████╗███████╗██╗███████╗████████╗███████╗███████╗███╗   ██╗");
			outputProvider.DisplayLine("██╔════╝ ██╔══██╗████╗ ████║██╔════╝██╔════╝██║██╔════╝╚══██╔══╝██╔════╝██╔════╝████╗  ██║");
			outputProvider.DisplayLine("██║  ███╗███████║██╔████╔██║█████╗  █████╗  ██║█████╗     ██║   █████╗  █████╗  ██╔██╗ ██║");
			outputProvider.DisplayLine("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ██╔══╝  ██║██╔══╝     ██║   ██╔══╝  ██╔══╝  ██║╚██╗██║");
			outputProvider.DisplayLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗██║     ██║██║        ██║   ███████╗███████╗██║ ╚████║");
			outputProvider.DisplayLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝╚═╝        ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═══╝");
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("Please enter your name: ");
		}
	}
}