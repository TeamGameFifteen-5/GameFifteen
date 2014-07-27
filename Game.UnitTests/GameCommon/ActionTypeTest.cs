namespace Game.UnitTests.GameCommon
{
	using Game.Common;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;

	[TestClass]
	public class ActionTypeTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetWithNullName()
		{
			ActionType.Get(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetWithEmptyName()
		{
			ActionType.Get(string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetWithWhiteSpaceName()
		{
			ActionType.Get("         ");
		}

		[TestMethod]
		public void GetWithValidName()
		{
			var name = "Action";
			var action = ActionType.Get(name);
			Assert.AreEqual(action.Name, name);
		}
	}
}