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
			this.Size = size;
			this.DefaultRandomizer = defaultRandomizer ?? new DefaultFieldRandomizer(DefaultRandomGenerator.Instance);
			this.DefaultFiller = defaultFiller ?? new DefaultFieldFiller();
		}

		#region Properties

		public int[,] Area { get; set; }

		public int Size { get; private set; }

		public Position Position { get; set; }

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

		public void RandomizeField(Difficulty difficulty, IFieldRandomizer randomizer = null)
		{
			(randomizer ?? this.DefaultRandomizer).Randomize(this, difficulty);
		}

		public void Fill(IFieldFiller filler = null)
		{
			(filler ?? this.DefaultFiller).Fill(this, this.Size);
		}

		public bool IsInLimits(int row, int col)
		{
			bool isInRowLimits = row >= 0 && row < this.Size;
			bool isInColLimits = col >= 0 && col < this.Size;
			return isInRowLimits && isInColLimits;
		}

		#region IEnumerable

		IEnumerator<IEnumerable<int>> IEnumerable<IEnumerable<int>>.GetEnumerator()
		{
			for (int row = 0; row < this.Size; row++)
			{
				int[] rowColumns = new int[this.Size];
				for (int col = 0; col < this.Size; col++)
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