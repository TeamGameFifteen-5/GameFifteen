namespace Game.UI.Renderers
{
	public class DefaultStartRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine(" ██████╗  █████╗ ███╗   ███╗███████╗███████╗██╗███████╗████████╗███████╗███████╗███╗   ██╗");
			outputProvider.DisplayLine("██╔════╝ ██╔══██╗████╗ ████║██╔════╝██╔════╝██║██╔════╝╚══██╔══╝██╔════╝██╔════╝████╗  ██║");
			outputProvider.DisplayLine("██║  ███╗███████║██╔████╔██║█████╗  █████╗  ██║█████╗     ██║   █████╗  █████╗  ██╔██╗ ██║");
			outputProvider.DisplayLine("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ██╔══╝  ██║██╔══╝     ██║   ██╔══╝  ██╔══╝  ██║╚██╗██║");
			outputProvider.DisplayLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗██║     ██║██║        ██║   ███████╗███████╗██║ ╚████║");
			outputProvider.DisplayLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝╚═╝        ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═══╝");
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.Display("Please enter your name: ");

		}
	}
}