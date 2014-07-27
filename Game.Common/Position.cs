namespace Game.Common
{
	using Game.Common.Utils;
	using System;

	/// <summary>
	/// Represents a position.
	/// Implements Prototype Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.IPosition"/>
	[Serializable]
	public class Position : Clonable<Position>, IPosition
	{
		#region Constants

		/// <summary>
		/// The validation lower boundary.
		/// </summary>
		private const int VALIDATION_LOWER_BOUNDARY = 0;

		/// <summary>
		/// The validation upper boundary.
		/// </summary>
		private const int VALIDATION_UPPER_BOUNDARY = int.MaxValue;

		#endregion Constants

		#region Fields

		/// <summary>
		/// The x coordinate.
		/// </summary>
		private int _x;

		/// <summary>
		/// The y coordinate.
		/// </summary>
		private int _y;

		#endregion Fields

		/// <summary>
		/// Initializes a new instance of the Position class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Position(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		/// <summary>
		/// Gets or sets the x coordinate.
		/// </summary>
		/// <value>
		/// The x coordinate.
		/// </value>
		public int X
		{
			get
			{
				return this._x;
			}
			set
			{
				Validation.ThrowIfOutOfRange(value, VALIDATION_LOWER_BOUNDARY, VALIDATION_UPPER_BOUNDARY);
				this._x = value;
			}
		}

		/// <summary>
		/// Gets or sets the y coordinate.
		/// </summary>
		/// <value>
		/// The y coordinate.
		/// </value>
		public int Y
		{
			get
			{
				return this._y;
			}
			set
			{
				Validation.ThrowIfOutOfRange(value, VALIDATION_LOWER_BOUNDARY, VALIDATION_UPPER_BOUNDARY);
				this._y = value;
			}
		}

		IPosition IClonable<IPosition>.Clone()
		{
			return this.Clone();
		}

		IPosition IClonable<IPosition>.DeepCopy()
		{
			return this.DeepCopy();
		}
	}
}