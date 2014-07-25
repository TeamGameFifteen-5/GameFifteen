namespace Game.Common.Map.Movement
{
    using System;
    using Game.Common.Map;
 
    public class StraightMovement : IMovement
    {
        private IField _gameField;

        public StraightMovement(IField gameField)
        {
            this._gameField = gameField;
        }

        public bool Move(Direction direction)
        {
            int row = this._gameField.StartPosition.Y;
            int col = this._gameField.StartPosition.X;

            switch (direction)
            {
                case Direction.Up:
                    row--;
                    break;

                case Direction.Down:
                    row++;
                    break;

                case Direction.Left:
                    col--;
                    break;

                case Direction.Right:
                    col++;
                    break;

                default:
                    throw new NotImplementedException();
            }

            if (this._gameField.IsInLimits(row, col))
            {
                int numberForSwap = this._gameField.Area[row, col];
                this._gameField[row, col] = this._gameField[this._gameField.StartPosition.Y, this._gameField.StartPosition.X];
                this._gameField[this._gameField.StartPosition.Y, this._gameField.StartPosition.X] = numberForSwap;
                this._gameField.StartPosition.Y = row;
                this._gameField.StartPosition.X = col;
                return true;
            }

            return false;
        }
    }
}
