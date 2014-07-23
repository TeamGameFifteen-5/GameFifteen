using Game.Core;
using Game.Core.Players;
using Game.Core.Stats;
using Game.Core.World;
using Game.UI;
using Game.UI.IOProviders;

namespace Game.App
{
	internal class App
	{
		public static void Main(string[] args)
		{
			var consoleIOProvider = new ConsoleIOProvider();
			var player = new Player();
			var playerStats = new PlayerStats();

			var field = new Field();

			var gameEngine = new CoreEngine(consoleIOProvider, field);
			var gameUI = new UIEngine(gameEngine, player, consoleIOProvider);
			gameUI.Start();
		}
	}
}