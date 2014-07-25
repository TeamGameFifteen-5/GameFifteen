namespace Game.Common.Map.Decorators
{
	using Game.Common.Map.Movement;

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