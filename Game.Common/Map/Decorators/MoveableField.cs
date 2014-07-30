namespace Game.Common.Map.Decorators
{
	using Game.Common.Map.Movement;
	using Game.Common.Utils;

	/// <summary>
	/// Represents Moveable field.
	/// Implements Decorator Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.IMoveable"/>
	public class MoveableField : IMoveable
	{
        /// <summary>
        /// The field.
        /// </summary>
        private readonly IField _field;

        /// <summary>
        /// The movement.
        /// </summary>
        private readonly IMovement _movement;

		/// <summary>
		/// Initializes a new instance of the MoveableField class.
		/// </summary>
		/// <param name="field">   The field.</param>
		/// <param name="movement">(optional) The movement.</param>
		public MoveableField(IField field, IMovement movement = null)
		{
			Validation.ThrowIfNull(field);

			this._field = field;
			this._movement = movement ?? new BackwardMovement(field);
		}

		/// <summary>
		/// Moves the given direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns>
		/// true if it succeeds, false if it fails.
		/// </returns>
		public bool Move(Direction direction)
		{
			Validation.ThrowIfInvalidEnumValue(direction);
			return this._movement.Move(direction);
		}
	}
}