namespace Game.Core.Movement
{
    using System;
    using Game.Common;
    using Game.Core.World;

    public class BackwardMovement : IMovement
    {
        private IField _gameField;

        public BackwardMovement(IField gameField)
        {
            this._gameField = gameField;
        }

        public bool Move(Direction direction)
        {
            int row = this._gameField.Position.Y;
            int col = this._gameField.Position.X;

            switch (direction)
            {
                case Direction.Up:
                    row++;
                    break;

                case Direction.Down:
                    row--;
                    break;

                case Direction.Left:
                    col++;
                    break;

                case Direction.Right:
                    col--;
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
