﻿namespace Game.UnitTests.GameCore.ActionReceiver
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.Core.Actions.ActionReceiver;
    using Game.UnitTests.GameCore.SampleGameEngine;
    using Game.Common;
    using System.IO;
    using Game.Common.Stats;
    using System.Text;
    using Game.Common.Players;
    using Game.Common.Map.Movement;

    [TestClass]
    public class DefaultActionReceiverTests
    {
        private readonly DefaultActionReceiver receiver = new DefaultActionReceiver(FakeGameEngine.Engine);
        private readonly IPlayer player = FakeGameEngine.Player;
        private FileStream ostrm;
        private StreamWriter writer;
        private readonly TextWriter oldOut = Console.Out;
        private StreamReader reader;
        private readonly string filePath = "../../console-output.game15";

        private void ChangeConsoleOutPut()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                ostrm = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open console-output.game15 for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(writer);
        }

        private void ReverseConsoleOutPut()
        {
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }

        [TestMethod]
        public void IsValidExecuteWithUnmappedActionTypeNameTest()
        {
            ChangeConsoleOutPut();

            var actionType = ActionType.Get("Unmapped");
            receiver.Execute(actionType);

            ReverseConsoleOutPut();

            using (reader = new StreamReader(filePath))
            {
                string result = reader.ReadToEnd();

                Assert.AreEqual(result, "Illegal move!" + Environment.NewLine);
            }
        }

        [TestMethod]
        public void IsValidExecuteWithExitActionTypeNameTest()
        {
            ChangeConsoleOutPut();

            var actionType = ActionType.Get("Exit");
            receiver.Execute(actionType);

            ReverseConsoleOutPut();

            using (reader = new StreamReader(filePath))
            {
                string result = reader.ReadToEnd();

                Assert.AreEqual(result, "Good bye!" + Environment.NewLine);
            }
        }

        [TestMethod]
        public void IsValidExecuteWithIllegalCommandActionTypeNameTest()
        {
            ChangeConsoleOutPut();

            var actionType = ActionType.Get("IlligalCommand");
            receiver.Execute(actionType);

            ReverseConsoleOutPut();

            using (reader = new StreamReader(filePath))
            {
                string result = reader.ReadToEnd();

                Assert.AreEqual(result, "Illegal command!" + Environment.NewLine);
            }
        }

        [TestMethod]
        public void IsValidExecuteWithScoresActionTypeNameTest()
        {
            ChangeConsoleOutPut();

            var actionType = ActionType.Get("Scores");
            receiver.Execute(actionType);

            ReverseConsoleOutPut();

            var UP_DOWN_TABLE_FRAME = "-------------------------";
            var stats = InMemoryScores.Instance;
            var playerScores = stats.Load();

            var expectedResult = new StringBuilder();

            expectedResult.AppendLine(UP_DOWN_TABLE_FRAME);


            foreach (var playerScore in playerScores)
            {
                expectedResult.AppendFormat("{0}: {1}{2}", playerScore.Name, playerScore.Value, Environment.NewLine);
            }

            //if (expectedResult.ToString() == UP_DOWN_TABLE_FRAME + Environment.NewLine)
            //{
            //    expectedResult.AppendLine("");
            //}

            expectedResult.AppendLine(UP_DOWN_TABLE_FRAME);


            using (reader = new StreamReader(filePath))
            {
                string result = reader.ReadToEnd();
                string expected = expectedResult.ToString();
                Assert.AreEqual(result, expected);
            }
        }

        [TestMethod]
        public void IsValidIncrementsPlayerScoreTest()
        {
            // Assigned field position and player and player score
            FakeGameEngine.Engine.StartGame();

            var playerScoreBeforeAction = player.Score;
            var actionType = ActionType.Get("Down");
            receiver.Execute(actionType);

            var playerScoreAfterAction = player.Score;
            playerScoreBeforeAction++;

            Assert.AreEqual(playerScoreBeforeAction, playerScoreAfterAction);
        }

        [TestMethod]
        public void IsValidDirectionChangeTest()
        {
            // Assigned field position and player and player score
            FakeGameEngine.Engine.StartGame();

            var movement = FakeGameEngine.Movement as BackwardMovement;

            if (movement != null)
            {
                IsValidBackwardMovementTest();
            }
            else
            {
                IsValidStraightMovementTest();
            }
        }

        [Ignore]
        private void IsValidBackwardMovementTest()
        {
            var startPositionX = FakeGameEngine.Field.Position.X;
            var startPositionY = FakeGameEngine.Field.Position.Y;

            receiver.Execute(ActionType.Get("Right"));
            Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX - 1, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Down"));
            Assert.AreEqual(startPositionY - 1, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX - 1, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Left"));
            Assert.AreEqual(startPositionY - 1, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Up"));
            Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);
        }

        [Ignore]
        private void IsValidStraightMovementTest()
        {
            var startPositionX = FakeGameEngine.Field.Position.X;
            var startPositionY = FakeGameEngine.Field.Position.Y;

            receiver.Execute(ActionType.Get("Right"));
            Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX + 1, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Down"));
            Assert.AreEqual(startPositionY + 1, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX + 1, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Left"));
            Assert.AreEqual(startPositionY + 1, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);

            receiver.Execute(ActionType.Get("Up"));
            Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
            Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);

        }
    }
}
