using Game.Common;
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

		public CoreEngine(IInputProvider inputProvider, IField field, IMovement movement = null, ISolvedChecker solvedChecker = null)
		{
			this._inputProvider = inputProvider;
			this._field = field;

			this.Movement = movement ?? new StraightMovement(field);
			this.SolvedChecker = solvedChecker ?? new DefaultSolvedChecker();
		}

		#region Events

		public event Action GameStart;

		public event Action GameEnd;

		public event Action GameExit;

		public event Action GameMovement;

		public event Action GameIllegalMove;

		public event Action GameIllegalCommand;

		public event FieldEvent GameInvalidate;

		#endregion Events

		public IMovement Movement { get; set; }

		public ISolvedChecker SolvedChecker { get; set; }

		#region Methods

		public void Start()
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
					Direction direction;

					switch (key)
					{
						case ActionType.Unmapped:
							this.OnGameIllegalMove();
							continue;
						case ActionType.Up:
							direction = Direction.Up;
							break;

						case ActionType.Down:
							direction = Direction.Down;
							break;

						case ActionType.Left:
							direction = Direction.Left;
							break;

						case ActionType.Right:
							direction = Direction.Right;
							break;

						case ActionType.Exit:
							this.OnGameExit();
							_repeat = false;
							exitGame = true;
							continue;

						case ActionType.Reset:
							this.RestartGame();
							continue;

						case ActionType.Scores:
							// PrintTopHighScore();
							continue;

						default:
							this.OnGameIllegalCommand();
							continue;
					}

					if (!this.Move(direction))
					{
						this.OnGameIllegalMove();
					}

					isSolved = this.IsGameSolved();
				}

				if (isSolved)
				{
					this.OnGameEnd();
				}
			}
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

		private bool Move(Direction direction)
		{
			var canMove = this.Movement.Move(direction);
			this.OnGameInvalidate();

			return canMove;
		}

		private bool IsGameSolved()
		{
			return this.SolvedChecker.IsSolved(this._field);
		}

		private void RestartGame()
		{
			this._field.RandomizeField();
			this.OnGameInvalidate();
		}

		#endregion Methods
	}
}