namespace Game.Common.Map.Movement
{
	using Game.Common.Map;

	/// <summary>
	/// Straight movement.
	/// </summary>
	/// <seealso cref="Game.Common.Map.Movement.Movement"/>
	public class StraightMovement : Movement
	{
		/// <summary>
		/// Initializes a new instance of the StraightMovement class.
		/// </summary>
		/// <param name="gameField">The game field.</param>
		public StraightMovement(IField gameField)
			: base(gameField)
		{
		}

		/// <summary>
		/// Move to direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <param name="row">		[in,out] The row.</param>
		/// <param name="col">		[in,out] The col.</param>
		protected override void MoveToDirection(Direction direction, ref int row, ref int col)
		{
			switch (direction)
			{
				case Direction.Up:
					row--;
					break;

				case Direction.Down:
					row++;
					break;

				case Direction.Left:
					col--;
					break;

				case Direction.Right:
					col++;
					break;
			}
		}
	}
}