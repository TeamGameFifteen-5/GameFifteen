﻿namespace Game.App
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
			var ioProvider = new ConsoleIOProvider();
			var player = new Player();
			var field = new Field();

			var gameUISettngs = new DefaultUIEngineSettings(ioProvider, player);
			var gameUI = new UIEngine(gameUISettngs);
			var gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(gameUI, field, player, InMemoryScores.Instance);
			var gameEngine = new GameEngine(gameEngineSettings);
			gameEngine.Start();
		}
	}
}