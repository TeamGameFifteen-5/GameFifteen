using Game.Core.World;
using System;

namespace Game.Core.Movement
{
	public class StraightMovement : IMovement
	{
		private IField _gameField;

		public StraightMovement(IField gameField)
		{
			this._gameField = gameField;
		}

		public bool Move(MovementDirection direction)
		{
			int row = this._gameField.Position.Y;
			int col = this._gameField.Position.X;

			switch (direction)
			{
				case MovementDirection.Up:
					row--;
					break;

				case MovementDirection.Down:
					row++;
					break;

				case MovementDirection.Left:
					col--;
					break;

				case MovementDirection.Right:
					col++;
					break;

				default:
					throw new NotImplementedException();
			}

			if (this._gameField.IsInLimits(row, col))
			{
				int numberForSwap = this._gameField.Area[row, col];
				this._gameField[row, col] = this._gameField[this._gameField.Position.Y, this._gameField.Position.X];
				this._gameField[this._gameField.Position.Y, this._gameField.Position.X] = numberForSwap;
				this._gameField.Position.Y = row;
				this._gameField.Position.X = col;
				return true;
			}

			return false;
		}
	}
}