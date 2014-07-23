using Game.Common;
using Game.Core.Utils;
using Game.Core.World.Fillers;
using Game.Core.World.Randomizers;

namespace Game.Core.World
{
	/// <summary>
	/// Represents the game field.
	/// Implements Bridge and Strategy Design Patterns.
	/// </summary>
	/// <seealso cref="Game.Core.World.IField"/>
	public class Field : IField
	{
		#region Constants

		private const int SIZE = 4;

		#endregion Constants

		public Field(int size = SIZE, IFieldRandomizer defaultRandomizer = null, IFieldFiller defaultFiller = null)
		{
			this.DefaultRandomizer = defaultRandomizer ?? new DefaultFieldRandomizer(DefaultRandomGenerator.Instance);
			this.DefaultFiller = defaultFiller ?? new DefaultFieldFiller();

			var lastPosition = size - 1;
			this.Position = new Position(lastPosition, lastPosition);

			this.Fill(size);
		}

		#region Properties

		protected IFieldRandomizer DefaultRandomizer { get; set; }

		protected IFieldFiller DefaultFiller { get; set; }

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
			(randomizer ?? this.DefaultRandomizer).Randomize(this);
		}

		public void Fill(int size, IFieldFiller filler = null)
		{
			(filler ?? this.DefaultFiller).Fill(this, size);
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