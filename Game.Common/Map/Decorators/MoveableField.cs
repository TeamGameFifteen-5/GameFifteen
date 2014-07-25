namespace Game.Common.Map.Decorators
{
	using Game.Common.Map.Movement;

	/// <summary>
	/// Represents Moveable field.
	/// Implements Decorator Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.IMoveable"/>
	public class MoveableField : IMoveable
	{
		private IField _field;
		private IMovement _movement;

		public MoveableField(IField field, IMovement movement = null)
		{
			this._field = field;
			this._movement = movement ?? new BackwardMovement(field);
		}

		public bool Move(Direction direction)
		{
			return this._movement.Move(direction);
		}
	}
}