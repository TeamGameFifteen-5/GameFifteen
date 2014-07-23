using Game.Common;
using Game.Core.Actions.ActionProviders;
using Game.Core.Input;
using Game.Core.Movement;
using Game.Core.SolvedCheckers;
using Game.Core.World;
using System;

namespace Game.Core
{
	public delegate void FieldEvent(IField field);

	public class CoreEngine : ICoreEngine
	{
		private static bool _repeat = true;

		#region Fields

		private IInputProvider _inputProvider;
		private IField _field;

		#endregion Fields

		public CoreEngine(IInputProvider inputProvider, IField field, IActionProvider actionProvider = null, IMovement movement = null, ISolvedChecker solvedChecker = null)
		{
			this._inputProvider = inputProvider;
			this._field = field;

			this.ActionProvider = actionProvider ?? new DefaultActionProvider(this);
			this.Movement = movement ?? new StraightMovement(field);
			this.SolvedChecker = solvedChecker ?? new DefaultSolvedChecker();
		}

		#region Events

		public event Action GameStart;

		public event Action GameEnd;

		public event Action GameExit;

		public event Action GameMovement;

		public event Action GameShowScore;

		public event Action GameIllegalMove;

		public event Action GameIllegalCommand;

		public event FieldEvent GameInvalidate;

		#endregion Events

		public IActionProvider ActionProvider { get; set; }

		public IMovement Movement { get; set; }

		public ISolvedChecker SolvedChecker { get; set; }

		#region Methods

		public virtual void Start()
		{
			this._field.RandomizeField();

			while (_repeat)
			{
				this.OnGameStart();
				this.OnGameInvalidate();

				bool isSolved = this.IsGameSolved();
				bool exitGame = false;
				while (!exitGame || !isSolved)
				{
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
			this.OnGameInvalidate();

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
			_repeat = false;
		}

		public virtual void RestartGame()
		{
			this._field.RandomizeField();
			this.OnGameInvalidate();
		}

		public virtual void IllegalMove()
		{
			this.OnGameIllegalMove();
		}

		public virtual void IllegalCommand()
		{
			this.OnGameIllegalCommand();
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

		private void OnGameInvalidate()
		{
			if (this.GameInvalidate != null)
			{
				this.GameInvalidate(this._field);
			}
		}

		#endregion Events

		private bool IsGameSolved()
		{
			return this.SolvedChecker.IsSolved(this._field);
		}

		#endregion Methods
	}
}