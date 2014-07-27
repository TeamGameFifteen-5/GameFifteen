namespace Game.UnitTests.GameCommon.CustomEvents
{
	using Game.Common.CustomEvents;
	using Game.Common.Map;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class CustomEventTest
	{
		[TestMethod]
		public void GetEventArgs()
		{
			var field = new Field();
			ICustomEvent customEvent = new FieldInvalidateEvent(field);
			Assert.AreEqual(field, customEvent.EventArgs);
		}
	}
}