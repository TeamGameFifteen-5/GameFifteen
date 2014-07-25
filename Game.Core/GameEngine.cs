namespace Game.Core
{
	using Game.Common;
	using Game.Common.CustomEvents;
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Decorators;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core.Actions.ActionProviders;
	using Game.Core.Actions.ActionReceiver;
	using Game.UI;
	using Game.UI.IOProviders;
	using System;

	public delegate void CustomEventHandler(object eventObject);

	/// <summary>
	/// Represents the Core engine.
	/// Implements Observer, Bridge and Command Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Core.IGameEngine"/>
	public class GameEngine : IDefaultGameEngine
	{
		private bool _gameExit = false;

		public GameEngine(IGameEngineSettings<IDefaultUIEngine, IIntegerStats> settings)
		{
			this.Difficulty = settings.Difficulty;
			this.UIEngine = settings.UIEngine;
			this.InputProvider = this.UIEngine.InputProvider;
			this.Field = settings.Field;
			this.Player = settings.Player;
			this.HighScores = settings.HighScores;

			this.ActionProvider = settings.ActionProvider;
			this.GameOverChecker = settings.GameOverChecker;

			this.MoveableEntity = new MoveableField(this.Field, settings.Movement);
			this.ActionReceiver = new DefaultActionReceiver(this);
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

		#region Properties

		public virtual Difficulty Difficulty { get; set; }

		public virtual IDefaultUIEngine UIEngine { get; set; }

		public virtual IInputProvider InputProvider { get; set; }

		public virtual IField Field { get; set; }

		public virtual IPlayer Player { get; set; }

		public virtual IIntegerStats HighScores { get; set; }

		public virtual IMoveable MoveableEntity { get; set; }

		public virtual IGameOverChecker GameOverChecker { get; set; }

		protected virtual IActionProvider ActionProvider { get; set; }

		protected virtual IActionReceiver ActionReceiver { get; set; }

		#endregion Properties

		#region Methods

		public virtual void Start()
		{
			while (!this._gameExit)
			{
				this.Field.RandomizeField(this.Difficulty);
				this.OnGameStart();
				this.FieldInvalidate();

				bool isSolved = this.IsItGameOver();
				while (!this._gameExit && !isSolved)
				{
					this.OnGameMovement();

					var key = this.InputProvider.GetKeyInput();
					var action = this.ActionProvider.GetAction(key, this.ActionReceiver);
					action.Execute();

					isSolved = this.IsItGameOver();
				}

				if (isSolved)
				{
					this.OnGameEnd();

					var playerScore = new NameValue<int>(this.Player.Name, this.Player.Score);
					this.HighScores.Save(playerScore);
				}
			}
		}

		public virtual bool Move(Direction direction)
		{
			var canMove = this.MoveableEntity.Move(direction);
			this.FieldInvalidate();

			if (!canMove)
			{
				this.OnGameIllegalMove();
			}

			return canMove;
		}

		public virtual void Exit()
		{
			this.OnGameExit();
			this._gameExit = true;
		}

		public virtual void RestartGame()
		{
			this.Field.RandomizeField(this.Difficulty);
			this.FieldInvalidate();
		}

		public virtual void IllegalMove()
		{
			this.OnGameIllegalMove();
		}

		public virtual void IllegalCommand()
		{
			this.OnGameIllegalCommand();
		}

		public virtual void FieldInvalidate()
		{
			this.OnGameCustomEvent(new FieldInvalidateEvent(this.Field));
		}

		public virtual void ShowScore()
		{
			this.OnGameCustomEvent(new ShowScoreEvent(this.HighScores));
		}

		protected virtual bool IsItGameOver()
		{
			return this.GameOverChecker.IsItOver(this.Field);
		}

		protected virtual void AttachUIToEvents()
		{
			this.GameStart += this.UIEngine.OnGameStart;
			this.GameEnd += this.UIEngine.OnGameEnd;
			this.GameExit += this.UIEngine.OnGameExit;
			this.GameMovement += this.UIEngine.OnGameMovement;
			this.GameIllegalMove += this.UIEngine.OnGameIllegalMove;
			this.GameIllegalCommand += this.UIEngine.OnGameIllegalCommand;
			this.GameCustomEvent += this.UIEngine.OnGameCustomEvent;
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

		private void OnGameCustomEvent(object eventObject)
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