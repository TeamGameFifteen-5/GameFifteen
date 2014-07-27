namespace Game.UnitTests.GameCommon.Map.Movement
{
	using Game.Common;
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class StraightMovementTest
	{
		private IField _field;
		private IMovement _movement;
		private IPosition _originalPosition;

		[TestInitialize]
		public void Init()
		{
			this._field = new Field();
			this._field.Position = new Position(2, 2);
			this._originalPosition = this._field.Position.Clone();
			this._movement = new StraightMovement(this._field);
		}

		[TestMethod]
		public void MoveUp()
		{
			this._movement.Move(Direction.Up);

			Assert.IsTrue(this._originalPosition.Y > this._field.Position.Y);
		}

		[TestMethod]
		public void MoveDown()
		{
			this._movement.Move(Direction.Down);

			Assert.IsTrue(this._originalPosition.Y < this._field.Position.Y);
		}

		[TestMethod]
		public void MoveLeft()
		{
			this._movement.Move(Direction.Left);

			Assert.IsTrue(this._originalPosition.X > this._field.Position.X);
		}

		[TestMethod]
		public void MoveRight()
		{
			this._movement.Move(Direction.Right);

			Assert.IsTrue(this._originalPosition.X < this._field.Position.X);
		}
	}
}