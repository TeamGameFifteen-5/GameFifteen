namespace Game.App
{
	using Game.Common;
	using Game.Common.Map;
	using Game.Common.Players;
	using Game.Common.Stats;
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
			var gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(Difficulty.Normal, gameUI, field, player, InMemoryScores.Instance);
			var gameEngine = new GameEngine(gameEngineSettings);
			gameEngine.Start();
		}
	}
}