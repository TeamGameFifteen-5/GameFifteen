namespace Game.Common.Map.Movement
{
	using Game.Common.Utils;

	/// <summary>
	/// Represents abstract Movement.
	/// Implements Template Method Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.Map.Movement.IMovement"/>
	public abstract class Movement : IMovement
	{
        /// <summary>
        /// The game field.
        /// </summary>
        private readonly IField _gameField;

		/// <summary>
		/// Initializes a new instance of the StraightMovement class.
		/// </summary>
		/// <param name="gameField">The game field.</param>
		public Movement(IField gameField)
		{
			Validation.ThrowIfNull(gameField);

			this._gameField = gameField;
		}

		/// <summary>
		/// Moves to the given direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns>
		/// true if it succeeds, false if it fails.
		/// </returns>
		public bool Move(Direction direction)
		{
			Validation.ThrowIfInvalidEnumValue(direction);

			int row = this._gameField.Position.Y;
			int col = this._gameField.Position.X;
			this.MoveToDirection(direction, ref row, ref col);

			if (this._gameField.IsInLimits(row, col))
			{
				int numberForSwap = this._gameField.Area[row, col];
				this._gameField[row, col] = this._gameField[this._gameField.Position.Y, this._gameField.Position.X];
				this._gameField[this._gameField.Position.Y, this._gameField.Position.X] = numberForSwap;
				this._gameField.Position.Y = row;
				this._gameField.Position.X = col;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Move to direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <param name="row">		[in,out] The row.</param>
		/// <param name="col">		[in,out] The col.</param>
		protected abstract void MoveToDirection(Direction direction, ref int row, ref int col);
	}
}