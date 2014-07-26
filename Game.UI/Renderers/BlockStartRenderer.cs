namespace Game.UI.Renderers
{
	public class BlockStartRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine(@"   _____                      ______ _  __ _                  ");
			outputProvider.DisplayLine(@"  / ____|                    |  ____(_)/ _| |                 ");
			outputProvider.DisplayLine(@" | |  __  __ _ _ __ ___   ___| |__   _| |_| |_ ___  ___ _ __  ");
			outputProvider.DisplayLine(@" | | |_ |/ _` | '_ ` _ \ / _ \  __| | |  _| __/ _ \/ _ \ '_ \ ");
			outputProvider.DisplayLine(@" | |__| | (_| | | | | | |  __/ |    | | | | ||  __/  __/ | | |");
			outputProvider.DisplayLine(@"  \_____|\__,_|_| |_| |_|\___|_|    |_|_|  \__\___|\___|_| |_|");
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.Display("Please enter your name: ");
		}
	}
}