using Game.Core.Input;
using Game.Core.Movement;
using Game.Core.World;
using System;

namespace Game.Core
{
	public delegate void FieldEvent(IField field);

	public class CoreEngine : ICoreEngine
	{
		private static bool repeat = true;

		#region Fields

		private IInputProvider _inputProvider;
		private IField _field;
		private IMovement _movement;

		#endregion Fields

		#region Events

		public event Action GameStart;

		public event Action GameEnd;

		public event Action GameExit;

		public event Action GameMovement;

		public event Action GameIllegalMove;

		public event Action GameIllegalCommand;

		public event FieldEvent GameInvalidate;

		#endregion Events

		public CoreEngine(IInputProvider inputProvider, IField field, IMovement movement)
		{
			this._inputProvider = inputProvider;
			this._field = field;
			this._movement = movement;
		}

		#region Methods

		#region Events

		private void OnGameStart()
		{
			if (GameStart != null)
			{
				GameStart();
			}
		}

		private void OnGameEnd()
		{
			if (GameEnd != null)
			{
				GameEnd();
			}
		}

		private void OnGameExit()
		{
			if (GameExit != null)
			{
				GameExit();
			}
		}

		private void OnGameMovement()
		{
			if (GameMovement != null)
			{
				GameMovement();
			}
		}

		private void OnGameIllegalMove()
		{
			if (GameIllegalMove != null)
			{
				GameIllegalMove();
			}
		}

		private void OnGameIllegalCommand()
		{
			if (GameIllegalCommand != null)
			{
				GameIllegalCommand();
			}
		}

		private void OnGameInvalidate()
		{
			if (GameInvalidate != null)
			{
				GameInvalidate(this._field);
			}
		}

		#endregion Events

		public void Start()
		{
			this._field.RandomizeField();

			while (repeat)
			{
				this.OnGameStart();
				this.OnGameInvalidate();

				bool isSolved = IsGameSolved();
				bool exitGame = false;
				while (!exitGame || !isSolved)
				{
					this.OnGameMovement();

					var key = this._inputProvider.GetKeyInput();
					MovementDirection direction;

					switch (key)
					{
						case KeyType.Unmapped:
							this.OnGameIllegalMove();
							continue;
						case KeyType.Up:
							direction = MovementDirection.Up;
							break;

						case KeyType.Down:
							direction = MovementDirection.Down;
							break;

						case KeyType.Left:
							direction = MovementDirection.Left;
							break;

						case KeyType.Right:
							direction = MovementDirection.Right;
							break;

						case KeyType.Exit:
							this.OnGameExit();
							repeat = false;
							exitGame = true;
							continue;

						case KeyType.Reset:
							RestartGame();
							continue;

						case KeyType.Scores:
							//PrintTopHighScore();
							continue;

						default:
							this.OnGameIllegalCommand();
							continue;
					}

					if (!this.Move(direction))
					{
						this.OnGameIllegalMove();
					}

					isSolved = IsGameSolved();
				}

				if (isSolved)
				{
					this.OnGameEnd();
				}
			}
		}

		private bool Move(MovementDirection direction)
		{
			var canMove = this._movement.Move(direction);
			this.OnGameInvalidate();

			return canMove;
		}

		/// <summary>
		/// TODO: Refactor and implement pattern
		/// </summary>
		private bool IsGameSolved()
		{
			if (this._field[3, 3] == 0)
			{
				int numberInCurrentCell = 1;
				for (int row = 0; row < 4; row++)
				{
					for (int col = 0; col < 4; col++)
					{
						if (numberInCurrentCell <= 15)
						{
							if (this._field[row, col] == numberInCurrentCell)
							{
								numberInCurrentCell++;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		private void RestartGame()
		{
			this.OnGameInvalidate();
		}

		#endregion Methods
	}
}