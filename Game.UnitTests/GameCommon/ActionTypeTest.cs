namespace Game.UnitTests.GameCommon
{
	using Game.Common;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
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
		public void CompareEqualsOperatorWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType == name;
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareEqualsOperatorWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType == actionType2;
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareDifferenceOperatorWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType != name;
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void CompareDifferenceOperatorWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType != actionType2;
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void CompareEqualsWithNull()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType.Equals(null);
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void CompareEqualsWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = actionType.Equals(name);
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareEqualsWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType.Equals(actionType2);
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareObjectEqualsWithActionType()
		{
			var name = "Action";
			var actionType = (object)ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = actionType.Equals(actionType2);
			Assert.IsTrue(areEquals);
		}

		[TestMethod]
		public void CompareDifferenceWithString()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			bool areEquals = !actionType.Equals(name);
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void CompareDifferenceWithActionType()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			var actionType2 = ActionType.Get(name);
			bool areEquals = !actionType.Equals(actionType2);
			Assert.IsFalse(areEquals);
		}

		[TestMethod]
		public void GetHashCodeActionTypeWithName()
		{
			var name = "Action";
			var actionType = ActionType.Get(name);
			Assert.AreEqual(name.GetHashCode(), actionType.GetHashCode());
		}
	}
}