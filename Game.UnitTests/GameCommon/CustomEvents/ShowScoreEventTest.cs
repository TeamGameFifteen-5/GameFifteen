namespace Game.UnitTests.GameCommon.CustomEvents
{
	using Game.Common.CustomEvents;
	using Game.Common.Stats;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ShowScoreEventTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNull()
		{
			new ShowScoreEvent(null);
		}

		[TestMethod]
		public void GetEventArgs()
		{
			var scoreEvent = new ShowScoreEvent(InMemoryScores.Instance);
			Assert.AreEqual(scoreEvent.EventArgs, InMemoryScores.Instance);
		}
	}
}