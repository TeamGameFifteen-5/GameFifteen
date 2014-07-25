namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using Game.Common;
    using Game.Common.CustomEvents;
    using Game.Common.Map;
    using Game.Common.Movement;
    using Game.Common.Players;
    using Game.Common.Stats;
    using Game.Core.Actions.ActionProviders;
    using Game.Core.SolvedCheckers;
    using Game.UI;
    using Game.UI.IOProviders;

	public delegate void CustomEventHandler(Object eventObject);

	/// <summary>
	/// Represents the Core engine.
	/// Implements Observer, Bridge and Command Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Core.ICoreEngine"/>
	public class CoreEngine : ICoreEngine
	{
		private bool _gameExit = false;

		#region Fields

		private IUIEngine _uiEngine;
		private IInputProvider _inputProvider;
		private IField _field;
		private IPlayer _player;
        private IHighScores _highScores;
        private List<IPlayer> _highScoresList;

		#endregion Fields

		public CoreEngine(IUIEngine uiEngine, IField field, IPlayer player, IActionProvider actionProvider = null, IMovement movement = null, ISolvedChecker solvedChecker = null)
		{
			this._uiEngine = uiEngine;
			this._inputProvider = uiEngine.InputProvider;
			this._field = field;
			this._player = player;
            this._highScores = HighScores.Instance;

			this.ActionProvider = actionProvider ?? new DefaultActionProvider(this);
			this.Movement = movement ?? new BackwardMovement(field);
			this.SolvedChecker = solvedChecker ?? new DefaultSolvedChecker();

			this.AttachUIToEvents();
		}

		#region Events

		public event Action GameStart;

		public event Action GameEnd;

		public event Action GameExit;

		public event Action GameMovement;

		public event Action GameShowScore;

		public event Action GameIllegalMove;

		public event Action GameIllegalCommand;

		public event CustomEventHandler GameCustomEvent;

		#endregion Events

		public IActionProvider ActionProvider { get; set; }

		public IMovement Movement { get; set; }

		public ISolvedChecker SolvedChecker { get; set; }

		#region Methods

		public virtual void Start()
		{
			while (!this._gameExit)
			{
				this.OnGameStart();
                this.RestartGame();

				bool isSolved = this.IsGameSolved();
				while (!this._gameExit && !isSolved)
				{
                    this._highScoresList = this._highScores.Load();
                    if(this._player.Score == 0 && this._highScoresList.Count != 0){
                        this.ShowScore();
                    }

					this._player.Score++;
					this.OnGameMovement();

					var key = this._inputProvider.GetKeyInput();
					var action = this.ActionProvider.CreateAction(key);
					action.Execute();

					isSolved = this.IsGameSolved();
				}

				if (isSolved)
				{
					this.OnGameEnd();
				}
			}
		}

		public virtual void Move(Direction direction)
		{
			var canMove = this.Movement.Move(direction);
			this.Invalidate();

			if (!canMove)
			{
				this.OnGameIllegalMove();
			}
		}

		public virtual void ShowScore()
		{
			this.OnGameShowScore();
		}

		public virtual void Exit()
		{
			this.OnGameExit();
			this._gameExit = true;
		}

		public virtual void RestartGame()
		{
			this._field.RandomizeField();
			this.Invalidate();
		}

		public virtual void IllegalMove()
		{
			this.OnGameIllegalMove();
		}

		public virtual void IllegalCommand()
		{
			this.OnGameIllegalCommand();
		}

		public virtual void Invalidate()
		{
			this.OnGameCustomEvent(new FieldInvalidateEvent(this._field));
		}

		protected virtual bool IsGameSolved()
		{
			return this.SolvedChecker.IsSolved(this._field);
		}

		protected virtual void AttachUIToEvents()
		{
			this.GameStart += this._uiEngine.OnGameStart;
			this.GameEnd += this._uiEngine.OnGameEnd;
			this.GameExit += this._uiEngine.OnGameExit;
			this.GameMovement += this._uiEngine.OnGameMovement;
            this.GameShowScore += this._uiEngine.OnGameShowScore;
			this.GameIllegalMove += this._uiEngine.OnGameIllegalMove;
			this.GameIllegalCommand += this._uiEngine.OnGameIllegalCommand;
			this.GameCustomEvent += this._uiEngine.OnGameCustomEvent;
		}

		#region Events

		private void OnGameStart()
		{
			if (this.GameStart != null)
			{
				this.GameStart();
			}
		}

		private void OnGameEnd()
		{
			if (this.GameEnd != null)
			{
				this.GameEnd();
			}
		}

		private void OnGameExit()
		{
			if (this.GameExit != null)
			{
				this.GameExit();
			}
		}

		private void OnGameMovement()
		{
			if (this.GameMovement != null)
			{
				this.GameMovement();
			}
		}

		private void OnGameShowScore()
		{
			if (this.GameShowScore != null)
			{
				this.GameShowScore();
			}
		}

		private void OnGameIllegalMove()
		{
			if (this.GameIllegalMove != null)
			{
				this.GameIllegalMove();
			}
		}

		private void OnGameIllegalCommand()
		{
			if (this.GameIllegalCommand != null)
			{
				this.GameIllegalCommand();
			}
		}

		private void OnGameCustomEvent(Object eventObject)
		{
			if (this.GameCustomEvent != null)
			{
				this.GameCustomEvent(eventObject);
			}
		}

		#endregion Events

		#endregion Methods
	}
}