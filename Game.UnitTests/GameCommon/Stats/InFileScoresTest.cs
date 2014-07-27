namespace Game.UnitTests.GameCommon.Stats
{
	using Game.Common;
	using Game.Common.Stats;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.IO;
	using System.Linq;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class InFileScoresTest
	{
		[TestMethod]
		public void SaveInAndLoadScoresFromFile()
		{
			File.Delete(@"../../GameFifteen.game15");
			var stats = InFileScores.Instance;
			int index = 0;

			NameValue<int> playerScore1 = new NameValue<int>("player1", 2);
			stats.Save(playerScore1);
			NameValue<int> playerScore2 = new NameValue<int>("player2", 1);
			stats.Save(playerScore2);
			NameValue<int> playerScore3 = new NameValue<int>("player3", 4);
			stats.Save(playerScore3);
			NameValue<int> playerScore4 = new NameValue<int>("player4", 5);
			stats.Save(playerScore4);
			NameValue<int> playerScore5 = new NameValue<int>("player5", 6);
			stats.Save(playerScore5);
			NameValue<int> playerScore6 = new NameValue<int>("player6", 7);
			stats.Save(playerScore6);
			NameValue<int> playerScore7 = new NameValue<int>("player7", 7);
			stats.Save(playerScore7);
			var expected = new List<INameValue> { playerScore2, playerScore1, playerScore3, playerScore4, playerScore5 };
			var players = stats.Load();

			foreach (var player in players)
			{
				Assert.AreEqual(expected[index].Name, player.Name);
				Assert.AreEqual(expected[index].Value, player.Value);
				index++;
			}
		}

		[TestMethod]
		public void LoadWhenNoScoresInFile()
		{
			File.Delete(@"../../GameFifteen.game15");
			var stats = InFileScores.Instance.Load();
			Assert.IsFalse(stats.Any());

			var record = new NameValue<int>("record1", 1);
			InFileScores.Instance.Save(record);

			stats = InFileScores.Instance.Load();
			Assert.IsTrue(stats.Any());
		}
	}
}