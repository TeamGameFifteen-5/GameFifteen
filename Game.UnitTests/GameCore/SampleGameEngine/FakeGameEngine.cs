namespace Game.UnitTests.GameCore.SampleGameEngine
{
    using System;
    using Game.Common.Map;
    using Game.Common.Players;
    using Game.Common.Stats;
    using Game.Core;
    using Game.UI;
    using Game.UI.Windows.Console.IOProviders;
    using Game.Common.Map.Movement;
    
    public class FakeGameEngine
    {
        private static FakeGameEngine fakeGameEngine = new FakeGameEngine();
        private IDefaultGameEngine _sampleGameEngine;
        private IPlayer _player;
        private IField _field;
        private IMovement _movement;
        private GameEngineSettings<IDefaultUIEngine, IIntegerStats> _gameEngineSettings;
        private ConsoleIOProvider _ioProvider;
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
