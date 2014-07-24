using Game.Common.Utils;

namespace Game.Common.Map.Randomizers
{
	public class DefaultFieldRandomizer : IFieldRandomizer
	{
		private IRandomGenerator _randomGenerator;

		public DefaultFieldRandomizer(IRandomGenerator randomGenerator)
		{
			this._randomGenerator = randomGenerator;
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
				int randomNumber = this._randomGenerator.Next(3);
				if (randomNumber == 0)
				{
					var row = field.Position.Y - 1;
					var col = field.Position.X;
					if (row >= 0 && row <= 3 && col >= 0 && col <= 3)
					{
						var numberForSwap = field[field.Position.Y, field.Position.X];
						field[field.Position.Y, field.Position.X] = field[row, col];
						field[row, col] = numberForSwap;
						field.Position.Y = row;
						field.Position.X = col;
					}
					else
					{
						randomNumber++;
						i--;
					}
				}

				if (randomNumber == 1)
				{
					var row = field.Position.Y;
					var col = field.Position.X + 1;
					if (row >= 0 && row <= 3 && col >= 0 && col <= 3)
					{
						var numberForSwap = field[field.Position.Y, field.Position.X];
						field[field.Position.Y, field.Position.X] = field[row, col];
						field[row, col] = numberForSwap;
						field.Position.Y = row;
						field.Position.X = col;
					}
					else
					{
						randomNumber++;
						i--;
					}
				}

				if (randomNumber == 2)
				{
					var row = field.Position.Y + 1;
					var col = field.Position.X;
					if (row >= 0 && row <= 3 && col >= 0 && col <= 3)
					{
						var numberForSwap = field[field.Position.Y, field.Position.X];
						field[field.Position.Y, field.Position.X] = field[row, col];
						field[row, col] = numberForSwap;
						field.Position.Y = row;
						field.Position.X = col;
					}
					else
					{
						randomNumber++;
						i--;
					}
				}

				if (randomNumber == 3)
				{
					var row = field.Position.Y;
					var col = field.Position.X - 1;
					if (row >= 0 && row <= 3 && col >= 0 && col <= 3)
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
}