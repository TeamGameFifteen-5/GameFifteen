namespace Game.UI.Renderers
{
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultChooseDifficultyRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
            Validation.ThrowIfNull(outputProvider);
     
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
			outputProvider.DisplayLine();
			outputProvider.DisplayLine("1. Easy");
			outputProvider.DisplayLine("2. Normal");
			outputProvider.DisplayLine("3. Hard");
			outputProvider.DisplayLine();
			outputProvider.Display("[1|2|3]: ");
		}
	}
}