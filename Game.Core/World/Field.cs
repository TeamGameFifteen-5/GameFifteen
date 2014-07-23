using Game.Common;
using Game.Core.Utils;
using Game.Core.World.Fillers;
using Game.Core.World.Randomizers;

namespace Game.Core.World
{
	public class Field : IField
	{
		#region Constants

		private const int SIZE = 4;

		#endregion Constants

		#region Fields

		private IFieldRandomizer _defaultRandomizer;
		private IFieldFiller _defaultFiller;

		#endregion Fields

		public Field(int size = SIZE, IFieldRandomizer defaultRandomizer = null, IFieldFiller defaultFiller = null)
		{
			this._defaultRandomizer = defaultRandomizer ?? new DefaultFieldRandomizer(DefaultRandomGenerator.Instance);
			this._defaultFiller = defaultFiller ?? new DefaultFieldFiller();

			var lastPosition = size - 1;
			this.Position = new Position(lastPosition, lastPosition);

			this.Fill(size);
		}

		#region Properties

		public int[,] Area { get; set; }

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

		#endregion Properties

		#region Methods

		public void RandomizeField(IFieldRandomizer randomizer = null)
		{
			(randomizer ?? this._defaultRandomizer).Randomize(this);
		}

		public void Fill(int size, IFieldFiller filler = null)
		{
			(filler ?? this._defaultFiller).Fill(this, size);
		}

		public bool IsInLimits(int row, int col)
		{
			bool isInRowLimits = row >= 0 && row < this.Width;
			bool isInColLimits = col >= 0 && col < this.Height;
			return isInRowLimits && isInColLimits;
		}

		#endregion Methods
	}
}