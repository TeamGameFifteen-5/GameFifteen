namespace Game.Core
{
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Common.Utils;
	using Game.Core.Actions.ActionProviders;
	using Game.UI;

	public class GameEngineSettings<TUIEngine, TStats> : IGameEngineSettings<TUIEngine, TStats>
		where TUIEngine : IUIEngine
	{
		#region Fields

		private TUIEngine _uiEngine;
		private IField _field;
		private IPlayer _player;
		private TStats _highScores;
		private IMovement _movement;
		private IActionProvider _actionProvider;
		private IGameOverChecker _gameOverChecker;

		#endregion Fields

		#region Constructors

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores)
			: this(uiEngine, field, player, highscores, null, null, null)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IActionProvider actionProvider)
			: this(uiEngine, field, player, highscores, actionProvider, null, null)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IMovement movement)
			: this(uiEngine, field, player, highscores, null, movement, null)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IGameOverChecker gameOverChecker)
			: this(uiEngine, field, player, highscores, null, null, gameOverChecker)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IActionProvider actionProvider, IGameOverChecker gameOverChecker)
			: this(uiEngine, field, player, highscores, actionProvider, null, gameOverChecker)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IActionProvider actionProvider, IMovement movement)
			: this(uiEngine, field, player, highscores, actionProvider, movement, null)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IMovement movement, IGameOverChecker gameOverChecker)
			: this(uiEngine, field, player, highscores, null, movement, gameOverChecker)
		{
		}

		public GameEngineSettings(TUIEngine uiEngine, IField field, IPlayer player, TStats highscores, IActionProvider actionProvider, IMovement movement, IGameOverChecker gameOverChecker)
		{
			this.UIEngine = uiEngine;
			this.Field = field;
			this.Player = player;
			this.HighScores = highscores;

			this.Movement = movement ?? new BackwardMovement(this.Field);
			this.GameOverChecker = gameOverChecker ?? new DefaultGameOverChecker();
			this.ActionProvider = actionProvider ?? new DefaultActionProvider();
		}

		#endregion Constructors

		#region Properties

		public TUIEngine UIEngine
		{
			get
			{
				return this._uiEngine;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._uiEngine = value;
			}
		}

		public IField Field
		{
			get
			{
				return this._field;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._field = value;
			}
		}

		public IPlayer Player
		{
			get
			{
				return this._player;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._player = value;
			}
		}

		public TStats HighScores
		{
			get
			{
				return this._highScores;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._highScores = value;
			}
		}

		public IMovement Movement
		{
			get
			{
				return this._movement;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._movement = value;
			}
		}

		public IActionProvider ActionProvider
		{
			get
			{
				return this._actionProvider;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._actionProvider = value;
			}
		}

		public IGameOverChecker GameOverChecker
		{
			get
			{
				return this._gameOverChecker;
			}
			private set
			{
				Validation.ThrowIfNull(value);
				this._gameOverChecker = value;
			}
		}

		#endregion Properties
	}
}