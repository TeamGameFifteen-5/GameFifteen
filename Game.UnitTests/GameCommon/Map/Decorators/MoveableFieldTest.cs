namespace Game.UnitTests.GameCommon.Map.Decorators
{
	using Game.Common;
	using Game.Common.Map;
	using Game.Common.Map.Decorators;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class MoveableFieldTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNull()
		{
			new MoveableField(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void MoveToInvalidDirection()
		{
			var field = new Field();
			var moveableField = new MoveableField(field);
			moveableField.Move((Direction)9);
		}

		[TestMethod]
		public void MoveToValidDirection()
		{
			var field = new Field();
			var positionY = field.Position.Y;
			var moveableField = new MoveableField(field);
			moveableField.Move(Direction.Down);
			Assert.AreEqual(positionY - 1, field.Position.Y);
		}
	}
}