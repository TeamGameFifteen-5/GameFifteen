using Game.Core.Input;
using System;

namespace Game.UI.KeyMappings
{
	public class ConsoleKeyMapping : IKeyMapping<ConsoleKeyInfo>
	{
		public ActionType Map(ConsoleKeyInfo consoleKeyInfo)
		{
			ActionType key;

			switch (consoleKeyInfo.Key)
			{
				case ConsoleKey.W:
				case ConsoleKey.UpArrow:
					key = ActionType.Up;
					break;

				case ConsoleKey.S:
				case ConsoleKey.DownArrow:
					key = ActionType.Down;
					break;

				case ConsoleKey.A:
				case ConsoleKey.LeftArrow:
					key = ActionType.Left;
					break;

				case ConsoleKey.D:
				case ConsoleKey.RightArrow:
					key = ActionType.Right;
					break;

				case ConsoleKey.Escape:
				case ConsoleKey.Q:
					key = ActionType.Exit;
					break;

				case ConsoleKey.R:
					key = ActionType.Reset;
					break;

				case ConsoleKey.T:
					key = ActionType.Scores;
					break;

				default:
					key = ActionType.Unmapped;
					break;
			}

			return key;
		}
	}
}