namespace Game.UnitTests.GameCore.SampleGameEngine
{
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core;
	using Game.UI;
	using Game.UI.Windows.Console.IOProviders;
	using System.Diagnostics.CodeAnalysis;

	[ExcludeFromCodeCoverage]
	public class FakeGameEngine
	{
        private static readonly FakeGameEngine fakeGameEngine = new FakeGameEngine();
        private readonly IDefaultGameEngine _sampleGameEngine;
        private readonly IPlayer _player;
        private readonly IField _field;
        private readonly IMovement _movement;
        private readonly GameEngineSettings<IDefaultUIEngine, IIntegerStats> _gameEngineSettings;
        private readonly ConsoleIOProvider _ioProvider;

		private FakeGameEngine()
		{
			this._ioProvider = new ConsoleIOProvider();
			this._player = new Player();
			this._field = new Field();
			this._movement = new StraightMovement(this._field);

			var gameUISettngs = new DefaultUIEngineSettings<ConsoleIOProvider>(this._ioProvider, this._player);
			var gameUI = new UIEngine<ConsoleIOProvider>(gameUISettngs);
			this._gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(gameUI, this._field, this._player, InFileScores.Instance, this._movement);

			this._sampleGameEngine = new GameEngine(this._gameEngineSettings);
		}

		public static IDefaultGameEngine Engine
		{
			get
			{
				return fakeGameEngine._sampleGameEngine;
			}
		}

		public static IPlayer Player
		{
			get
			{
				return fakeGameEngine._player;
			}
		}

		public static IField Field
		{
			get
			{
				return fakeGameEngine._field;
			}
		}

		public static IMovement Movement
		{
			get
			{
				return fakeGameEngine._movement;
			}
		}

		public static GameEngineSettings<IDefaultUIEngine, IIntegerStats> GameEngineSettings
		{
			get
			{
				return fakeGameEngine._gameEngineSettings;
			}
		}

		public static ConsoleIOProvider IOProvider
		{
			get
			{
				return fakeGameEngine._ioProvider;
			}
		}
	}
}