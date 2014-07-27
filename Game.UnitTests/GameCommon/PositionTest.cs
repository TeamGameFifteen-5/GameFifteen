namespace Game.UnitTests.GameCommon
{
	using Game.Common;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class PositionTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void CreateWithNegativeValues()
		{
			new Position(-1, -1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SetXWithNegativeValues()
		{
			new Position(0, 0).X = -1;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SetYWithNegativeValues()
		{
			new Position(0, 0).Y = -1;
		}

		[TestMethod]
		public void GetX()
		{
			Assert.AreEqual(new Position(0, 1).X, 0);
		}

		[TestMethod]
		public void GetY()
		{
			Assert.AreEqual(new Position(0, 1).Y, 1);
		}

		[TestMethod]
		public void DeepCopy()
		{
			var position = new Position(0, 1);
			var clonablePosition = (IClonable<IPosition>)position;
			var positionDeepCopy = clonablePosition.DeepCopy();

			Assert.AreEqual(position.X, positionDeepCopy.X);
			Assert.AreEqual(position.Y, positionDeepCopy.Y);
		}
	}
}