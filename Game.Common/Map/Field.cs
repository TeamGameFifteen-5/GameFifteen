namespace Game.Common.Map
{
	using Game.Common.Map.Fillers;
	using Game.Common.Map.Randomizers;
	using Game.Common.Utils;
	using System.Collections.Generic;

	/// <summary>
	/// Represents the game field.
	/// Implements Bridge, Strategy and Iterator Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.World.IField"/>
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
			this.StartPosition = new Position(lastPosition, lastPosition);

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

		public Position StartPosition { get; protected set; }

		protected IFieldRandomizer DefaultRandomizer { get; set; }

		protected IFieldFiller DefaultFiller { get; set; }

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

		#region IEnumerable

		IEnumerator<IEnumerable<int>> IEnumerable<IEnumerable<int>>.GetEnumerator()
		{
			for (int row = 0; row < this.Height; row++)
			{
				int[] rowColumns = new int[this.Width];
				for (int col = 0; col < this.Width; col++)
				{
					rowColumns[col] = this.Area[row, col];
				}

				yield return rowColumns;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Area.GetEnumerator();
		}

		#endregion IEnumerable

		#endregion Methods
	}
}