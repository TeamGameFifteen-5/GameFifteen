namespace Game.UnitTests.GameCommon.Players
{
	using Game.Common.Players;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class PlayerTest
	{
		[TestMethod]
		public void CreateEmpty()
		{
			new Player();
		}

		[TestMethod]
		public void CreateWithValues()
		{
			var name = "Name";
			var score = 1;
			var player = new Player(name, score);

			Assert.AreEqual(player.Name, name);
			Assert.AreEqual(player.Score, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CreateWithNullName()
		{
			new Player(null, 0);
		}

		[TestMethod]
		public void GetName()
		{
			var player = new Player();
			Assert.AreEqual(player.Name, null);
		}

		[TestMethod]
		public void GetScore()
		{
			var player = new Player();
			Assert.AreEqual(player.Score, 0);
		}

		[TestMethod]
		public void SetName()
		{
			var player = new Player();
			player.Name = "Name";
		}

		[TestMethod]
		public void SetScore()
		{
			var player = new Player();
			player.Score = 3;
		}
	}
}