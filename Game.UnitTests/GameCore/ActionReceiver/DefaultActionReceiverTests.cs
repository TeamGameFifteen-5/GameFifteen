namespace Game.UnitTests.GameCore.ActionReceiver
{
	using Game.Common;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core.Actions.ActionReceiver;
	using Game.UnitTests.GameCore.SampleGameEngine;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.IO;
	using System.Linq;
	using System.Text;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultActionReceiverTests
	{
        private const int SIDE = 3;
		private readonly DefaultActionReceiver receiver = new DefaultActionReceiver(FakeGameEngine.Engine);
		private readonly IPlayer player = FakeGameEngine.Player;
		private readonly TextWriter oldOut = Console.Out;
		private readonly string filePath = "../../console-output.game15";
        private FileStream ostrm;
        private StreamWriter writer;

		[TestMethod]
		public void IsValidExecuteWithUnmappedActionTypeNameTest()
		{
            this.ChangeConsoleOutPut();

			var actionType = ActionType.Get("Unmapped");
            this.receiver.Execute(actionType);

            this.ReverseConsoleOutPut();

            string result = File.ReadAllLines(this.filePath).Last();

			Assert.AreEqual(result, "Illegal command!");
		}

		[TestMethod]
		public void IsValidExecuteWithExitActionTypeNameTest()
		{
            this.ChangeConsoleOutPut();

			var actionType = ActionType.Get("Exit");
            this.receiver.Execute(actionType);

            this.ReverseConsoleOutPut();

            string result = File.ReadAllLines(this.filePath).Last();

			Assert.AreEqual(result, "Good bye!");
		}

		[TestMethod]
		public void IsValidExecuteWithIllegalCommandActionTypeNameTest()
		{
            this.ChangeConsoleOutPut();

			var actionType = ActionType.Get("IlligalCommand");
            this.receiver.Execute(actionType);

            this.ReverseConsoleOutPut();

            string result = File.ReadAllLines(this.filePath).Last();

			Assert.AreEqual(result, "Illegal command!");
		}

		[TestMethod]
		public void IsValidExecuteWithScoresActionTypeNameTest()
		{
            this.ChangeConsoleOutPut();

			var actionType = ActionType.Get("Scores");
            this.receiver.Execute(actionType);

            this.ReverseConsoleOutPut();

			const var UP_DOWN_TABLE_FRAME = "-------------------------";
			var stats = InFileScores.Instance;
			var playerScores = stats.Load();

			var expectedResult = new StringBuilder();

			expectedResult.AppendLine(UP_DOWN_TABLE_FRAME);

			foreach (var playerScore in playerScores)
			{
				expectedResult.AppendFormat("{0}: {1}{2}", playerScore.Name, playerScore.Value, Environment.NewLine);
			}

			expectedResult.AppendLine(UP_DOWN_TABLE_FRAME);

            string[] resultLines = File.ReadAllLines(this.filePath);
			var scoreLines = resultLines.Skip(resultLines.Length - 7);
			string result = string.Join(Environment.NewLine, scoreLines) + Environment.NewLine;

			string expected = expectedResult.ToString();
			Assert.AreEqual(result, expected);
		}

		[TestMethod]
		public void IsValidIncrementsPlayerScoreTest()
		{
			// Assigned field position and player and player score
			FakeGameEngine.Engine.StartGame();

            var playerScoreBeforeAction = this.player.Score;
			var actionType = ActionType.Get("Down");
            this.receiver.Execute(actionType);

            var playerScoreAfterAction = this.player.Score;
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
                this.IsValidBackwardMovementTest();
			}
			else
			{
                this.IsValidStraightMovementTest();
			}

            this.receiver.Execute(ActionType.Get(DefaultActionTypes.Reset));
            this.receiver.Execute(ActionType.Get(DefaultActionTypes.Up));
            this.receiver.Execute(ActionType.Get(DefaultActionTypes.Down));
            this.receiver.Execute(ActionType.Get(DefaultActionTypes.Left));
            this.receiver.Execute(ActionType.Get(DefaultActionTypes.Right));

			for (int i = -1; i < SIDE; i++)
			{
                this.receiver.Execute(ActionType.Get(DefaultActionTypes.Up));
			}
		}

		[Ignore]
		private void IsValidBackwardMovementTest()
		{
			var startPositionX = FakeGameEngine.Field.Position.X;
			var startPositionY = FakeGameEngine.Field.Position.Y;

			if (startPositionX != 0)
			{
                this.receiver.Execute(ActionType.Get("Right"));
				Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX - 1, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionY != 0)
			{
                this.receiver.Execute(ActionType.Get("Down"));
				Assert.AreEqual(startPositionY - 1, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionX != SIDE)
			{
                this.receiver.Execute(ActionType.Get("Left"));
				Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX + 1, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionY != SIDE)
			{
                this.receiver.Execute(ActionType.Get("Up"));
				Assert.AreEqual(startPositionY + 1, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);
			}
		}

		[Ignore]
		private void IsValidStraightMovementTest()
		{
			var startPositionX = FakeGameEngine.Field.Position.X;
			var startPositionY = FakeGameEngine.Field.Position.Y;

			if (startPositionX != SIDE)
			{
                this.receiver.Execute(ActionType.Get("Right"));
				Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX + 1, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionY != SIDE)
			{
                this.receiver.Execute(ActionType.Get("Down"));
				Assert.AreEqual(startPositionY + 1, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionX != 0)
			{
                this.receiver.Execute(ActionType.Get("Left"));
				Assert.AreEqual(startPositionY, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX - 1, FakeGameEngine.Field.Position.X);

				FakeGameEngine.Field.Position.X = startPositionX;
				FakeGameEngine.Field.Position.Y = startPositionY;
			}

			if (startPositionY != 0)
			{
                this.receiver.Execute(ActionType.Get("Up"));
				Assert.AreEqual(startPositionY - 1, FakeGameEngine.Field.Position.Y);
				Assert.AreEqual(startPositionX, FakeGameEngine.Field.Position.X);
			}
		}

        private void ChangeConsoleOutPut()
        {
            try
            {
                if (!File.Exists(this.filePath))
                {
                    File.Create(this.filePath);
                }

                this.ostrm = new FileStream(this.filePath, FileMode.Truncate, FileAccess.Write);
                this.writer = new StreamWriter(this.ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open console-output.game15 for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(this.writer);
        }

        private void ReverseConsoleOutPut()
        {
            Console.SetOut(this.oldOut);
            this.writer.Close();
            this.ostrm.Close();
        }
	}
}