﻿namespace Game.UI.Renderers
{
	public class DefaultChooseDifficultyRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine();
			outputProvider.DisplayLine(@"   _____ _                            _____  _  __  __ _            _ _           ");
			outputProvider.DisplayLine(@"  / ____| |                          |  __ \(_)/ _|/ _(_)          | | |        _ ");
			outputProvider.DisplayLine(@" | |    | |__   ___   ___  ___  ___  | |  | |_| |_| |_ _  ___ _   _| | |_ _   _(_)");
			outputProvider.DisplayLine(@" | |    | '_ \ / _ \ / _ \/ __|/ _ \ | |  | | |  _|  _| |/ __| | | | | __| | | |  ");
			outputProvider.DisplayLine(@" | |____| | | | (_) | (_) \__ \  __/ | |__| | | | | | | | (__| |_| | | |_| |_| |_ ");
			outputProvider.DisplayLine(@"  \_____|_| |_|\___/ \___/|___/\___| |_____/|_|_| |_| |_|\___|\__,_|_|\__|\__, (_)");
			outputProvider.DisplayLine(@"                                                                           __/ |  ");
			outputProvider.DisplayLine(@"                                                                          |___/   ");
			outputProvider.DisplayLine("");
			outputProvider.DisplayLine("1. Easy");
			outputProvider.DisplayLine("2. Normal");
			outputProvider.DisplayLine("3. Hard");
			outputProvider.DisplayLine();
			outputProvider.Display("[1|2|3]: ");
		}
	}
}