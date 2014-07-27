namespace Game.UnitTests.GameCommon.CustomEvents
{
	using Game.Common.CustomEvents;
	using Game.Common.Map;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;

	[TestClass]
	public class FieldInvalidateEventTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNull()
		{
			new FieldInvalidateEvent(null);
		}

		[TestMethod]
		public void GetEventArgs()
		{
			var field = new Field();
			var scoreEvent = new FieldInvalidateEvent(field);
			Assert.AreEqual(scoreEvent.EventArgs, field);
		}
	}
}