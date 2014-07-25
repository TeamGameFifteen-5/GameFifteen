namespace Game.App
{
    using Game.Common.Map;
    using Game.Common.Players;
    using Game.Core;
    using Game.UI;
    using Game.UI.Windows.Console.IOProviders;

	internal class App
	{
		public static void Main(string[] args)
		{
			var consoleIOProvider = new ConsoleIOProvider();
			var player = new Player();
			var field = new Field();

			var gameUI = new UIEngine(player, consoleIOProvider);
			var gameEngine = new CoreEngine(gameUI, field, player);
			gameEngine.Start();
		}
	}
}