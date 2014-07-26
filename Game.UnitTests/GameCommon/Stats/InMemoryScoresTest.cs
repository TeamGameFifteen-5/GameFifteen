namespace Game.UnitTests.GameCommon.Stats
{
    using Game.Common;
    using Game.Common.Players;
    using Game.Common.Stats;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class InMemoryScoresTest
    {
        [TestMethod]
        public void SaveAndLoadScores()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            Player player4 = new Player();
            Player player5 = new Player();
            Player player6 = new Player();
            Player player7 = new Player();
            player1.Name = "player1";
            player1.Score = 2;
            player2.Name = "player2";
            player2.Score = 1;
            player3.Name = "player3";
            player3.Score = 4;
            player4.Name = "player4";
            player4.Score = 5;
            player5.Name = "player5";
            player5.Score = 6;
            player6.Name = "player6";
            player6.Score = 7;
            player7.Name = "player7";
            player7.Score = 7;

            var stats = InMemoryScores.Instance;
            int index = 0;

            NameValue<int> playerScore1 = new NameValue<int>(player1.Name, player1.Score);
            stats.Save(playerScore1);
            NameValue<int> playerScore2 = new NameValue<int>(player2.Name, player2.Score);
            stats.Save(playerScore2);
            NameValue<int> playerScore3 = new NameValue<int>(player3.Name, player3.Score);
            stats.Save(playerScore3);
            NameValue<int> playerScore4 = new NameValue<int>(player4.Name, player4.Score);
            stats.Save(playerScore4);
            NameValue<int> playerScore5 = new NameValue<int>(player5.Name, player5.Score);
            stats.Save(playerScore5);
            NameValue<int> playerScore6 = new NameValue<int>(player6.Name, player6.Score);
            stats.Save(playerScore6);
            NameValue<int> playerScore7 = new NameValue<int>(player7.Name, player7.Score);
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
        public void LoadWhenNoScores()
        {
            var stats = InMemoryScores.Instance;
            var player = stats.Load();
            bool isTrue = player.GetEnumerator().Current == null;
            Assert.IsTrue(isTrue);
        }
    }
}
