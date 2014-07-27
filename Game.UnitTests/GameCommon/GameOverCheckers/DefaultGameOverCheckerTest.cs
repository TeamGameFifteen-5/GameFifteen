namespace Game.UnitTests.GameCommon.GameOverCheckers
{
	using Game.Common;
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultGameOverCheckerTest
	{
		[TestMethod]
		public void GameNotOver()
		{
			var field = new Field();
			field.RandomizeField(Difficulty.Normal);
			var defaultGameOverChecker = new DefaultGameOverChecker();
			var isItOver = defaultGameOverChecker.IsItOver(field);
			Assert.IsFalse(isItOver);
		}

		[TestMethod]
		public void GameOver()
		{
			var field = new Field();
			field.Fill();
			var defaultGameOverChecker = new DefaultGameOverChecker();
			var isItOver = defaultGameOverChecker.IsItOver(field);
			Assert.IsTrue(isItOver);
		}
	}
}