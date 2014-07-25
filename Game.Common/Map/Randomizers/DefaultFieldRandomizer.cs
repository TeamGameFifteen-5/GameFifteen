using Game.Common.Utils;
using System;

namespace Game.Common.Map.Randomizers
{
	public class DefaultFieldRandomizer : IFieldRandomizer
	{
		private IRandomGenerator _randomGenerator;
        private int _totalElementsInDirection;
		public DefaultFieldRandomizer(IRandomGenerator randomGenerator)
		{
			this._randomGenerator = randomGenerator;
            _totalElementsInDirection = Enum.GetNames(typeof(Direction)).Length;
		}

		/// <summary>
		/// Randomizes the given field.
		/// TODO: Needs refactoring
		/// </summary>
		/// <param name="field">The field.</param>
		public void Randomize(IField field)
		{
			for (int i = 0; i < 1000; i++)
			{
                int row = 0; 
                int col = 0;

				int randomNumber = this._randomGenerator.Next(_totalElementsInDirection);

                Direction direction = (Direction)Enum.Parse(typeof(Direction), randomNumber.ToString());

                switch (direction)
                {
                    case Direction.Up:
                        row = field.Position.Y - 1;
                        col = field.Position.X;
                        break;

                    case Direction.Down:
                        row = field.Position.Y + 1;
                        col = field.Position.X;
                        break;

                    case Direction.Left:
                        row = field.Position.Y;
                        col = field.Position.X - 1;
                        break;

                    case Direction.Right:
                        row = field.Position.Y;
                        col = field.Position.X + 1;
                        break;
                }

                if (field.IsInLimits(row, col))
                {
                    var numberForSwap = field[field.Position.Y, field.Position.X];
                    field[field.Position.Y, field.Position.X] = field[row, col];
                    field[row, col] = numberForSwap;
                    field.Position.Y = row;
                    field.Position.X = col;
                }
                else
                {
                    i--;
                }
			}
		}
	}
}