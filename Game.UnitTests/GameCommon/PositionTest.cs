namespace Game.UnitTests.GameCommon
{
	using Game.Common;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;

	[TestClass]
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
	}
}