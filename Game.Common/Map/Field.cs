namespace Game.Common.Map
{
	using Game.Common.Map.Fillers;
	using Game.Common.Map.Randomizers;
	using Game.Common.Utils;
	using System.Collections.Generic;

	/// <summary>
	/// Represents the game field. Implements Bridge, Strategy and Iterator Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.Map.IField"/>
	public class Field : IField
	{
		#region Constants

		/// <summary>
		/// The size.
		/// </summary>
		private const int SIZE = 4;

		/// <summary>
		/// The size validation lowerboundary.
		/// </summary>
		private const int SIZE_VALIDATION_LOWERBOUNDARY = 2;

		/// <summary>
		/// The size validation upperboundary.
		/// </summary>
		private const int SIZE_VALIDATION_UPPERBOUNDARY = 20;

		/// <summary>
		/// The first position in field.
		/// </summary>
		private const int FIRST_POSITION_IN_FIELD = 0;

		#endregion Constants

		#region Fields

		/// <summary>
		/// The size.
		/// </summary>
		private int _size;

		/// <summary>
		/// The position.
		/// </summary>
		private IPosition _position;

		#endregion Fields

		/// <summary>
		/// Initializes a new instance of the Field class.
		/// </summary>
		/// <param name="size">				The size.</param>
		/// <param name="defaultRandomizer">(optional) the default randomizer.</param>
		/// <param name="defaultFiller">	(optional) the default filler.</param>
		public Field(int size = SIZE, IFieldRandomizer defaultRandomizer = null, IFieldFiller defaultFiller = null)
		{
			this.Size = size;
			this.DefaultRandomizer = defaultRandomizer ?? new DefaultFieldRandomizer(DefaultRandomGenerator.Instance);
			this.DefaultFiller = defaultFiller ?? new DefaultFieldFiller();

			this.Fill();
		}

		#region Properties

		/// <summary>
		/// Gets or sets the area.
		/// </summary>
		/// <value>
		/// The area.
		/// </value>
		public int[,] Area { get; set; }

		/// <summary>
		/// Gets the size.
		/// </summary>
		/// <value>
		/// The size.
		/// </value>
		public int Size
		{
			get
			{
				return this._size;
			}
			private set
			{
				Validation.ThrowIfOutOfRange(value, SIZE_VALIDATION_LOWERBOUNDARY, SIZE_VALIDATION_UPPERBOUNDARY);
				this._size = value;
			}
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		public IPosition Position
		{
			get
			{
				return this._position;
			}
			set
			{
				Validation.ThrowIfOutOfRange(value.X, FIRST_POSITION_IN_FIELD, this.Size - 1);
				Validation.ThrowIfOutOfRange(value.Y, FIRST_POSITION_IN_FIELD, this.Size - 1);
				this._position = value;
			}
		}

		/// <summary>
		/// Gets or sets the default randomizer.
		/// </summary>
		/// <value>
		/// The default randomizer.
		/// </value>
		protected IFieldRandomizer DefaultRandomizer { get; set; }

		/// <summary>
		/// Gets or sets the default filler.
		/// </summary>
		/// <value>
		/// The default filler.
		/// </value>
		protected IFieldFiller DefaultFiller { get; set; }

		/// <summary>
		/// Indexer to get or set items within this collection using array index syntax.
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="col">The col.</param>
		/// <returns>
		/// The indexed item.
		/// </returns>
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

		/// <summary>
		/// Randomize the field.
		/// </summary>
		/// <param name="difficulty">The difficulty.</param>
		/// <param name="randomizer">(optional) the randomizer.</param>
		public void RandomizeField(Difficulty difficulty, IFieldRandomizer randomizer = null)
		{
			(randomizer ?? this.DefaultRandomizer).Randomize(this, difficulty);
		}

		/// <summary>
		/// Fills the field with the specified filler and size.
		/// </summary>
		/// <param name="filler">(optional) the filler.</param>
		public void Fill(IFieldFiller filler = null)
		{
			(filler ?? this.DefaultFiller).Fill(this);
		}

		/// <summary>
		/// Check if 'row' and 'col' is in field limits.
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="col">The col.</param>
		/// <returns>
		/// true if in limits, false if not.
		/// </returns>
		public bool IsInLimits(int row, int col)
		{
			bool isInRowLimits = row >= FIRST_POSITION_IN_FIELD && row < this.Size;
			bool isInColLimits = col >= FIRST_POSITION_IN_FIELD && col < this.Size;
			return isInRowLimits && isInColLimits;
		}

		#region IEnumerable

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <typeparam name="int">Type of the int.</typeparam>
		/// <returns>
		/// The enumerator.
		/// </returns>
		IEnumerator<IEnumerable<int>> IEnumerable<IEnumerable<int>>.GetEnumerator()
		{
			for (int row = FIRST_POSITION_IN_FIELD; row < this.Size; row++)
			{
				int[] rowColumns = new int[this.Size];
				for (int col = FIRST_POSITION_IN_FIELD; col < this.Size; col++)
				{
					rowColumns[col] = this.Area[row, col];
				}

				yield return rowColumns;
			}
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>
		/// The enumerator.
		/// </returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Area.GetEnumerator();
		}

		#endregion IEnumerable

		#endregion Methods
	}
}