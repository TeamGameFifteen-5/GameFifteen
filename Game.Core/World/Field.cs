using Game.Common;
using Game.Core.Utils;

namespace Game.Core.World
{
	public class Field : IField
	{
		#region Constants

		private const int SIZE = 4;

		#endregion Constants

		#region Fields

		private IFieldRandomizer _randomizer;

		#endregion Fields

		public Field(int size = SIZE, IFieldRandomizer randomizer = null)
		{
			this._randomizer = randomizer ?? new DefaultFieldRandomizer(DefaultRandomGenerator.Instance);

			var lastPosition = size - 1;
			this.Position = new Position(lastPosition, lastPosition);

			this.CreateField(size);
		}

		#region Properties

		public int[,] Area { get; set; }

		public int this[int row, int col]
		{
			get
			{
				return this.Area[row, col];
			}
			set
			{
				this.Area[row, col] = value;
			}
		}

		public int Width
		{
			get
			{
				return this.Area.GetLength(0);
			}
		}

		public int Height
		{
			get
			{
				return this.Area.GetLength(1);
			}
		}

		public Position Position { get; protected set; }

		#endregion Properties

		#region Methods

		public void RandomizeField(IFieldRandomizer randomizer = null)
		{
			(randomizer ?? this._randomizer).Randomize(this);
		}

		#endregion Methods

		public bool IsInLimits(int row, int col)
		{
			bool isInRowLimits = row >= 0 && row < this.Width;
			bool isInColLimits = col >= 0 && col < this.Height;
			return isInRowLimits && isInColLimits;
		}

		protected virtual void CreateField(int size)
		{
			var area = new int[size, size];
			var currentNumber = 1;

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					area[row, col] = currentNumber++;
				}
			}

			int lastXY = size - 1;
			area[lastXY, lastXY] = 0;

			this.Area = area;
		}
	}
}