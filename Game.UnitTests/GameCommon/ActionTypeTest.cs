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

		[TestMethod]
		public void CompareEqualsWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType == name;
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareEqualsWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType == actionType2;
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareDifferentWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType != name;
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void CompareDifferentWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType != actionType2;
			Assert.IsFalse(areEquals);
		}
	}
}