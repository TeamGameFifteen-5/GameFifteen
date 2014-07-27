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

        private FakeGameEngine()
        {
            var ioProvider = new ConsoleIOProvider();
            this._player = new Player();
            this._field = new Field();
            this._movement = new StraightMovement(this._field);

            var gameUISettngs = new DefaultUIEngineSettings<ConsoleIOProvider>(ioProvider, this._player);
            var gameUI = new UIEngine<ConsoleIOProvider>(gameUISettngs);
            var gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(gameUI, this._field, this._player, InFileScores.Instance, this._movement);
           
            this._sampleGameEngine = new GameEngine(gameEngineSettings);
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
    }
}
