using Game.Common;
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
					key = ActionType.Get("Up");
					break;

				case ConsoleKey.S:
				case ConsoleKey.DownArrow:
					key = ActionType.Get("Down");
					break;

				case ConsoleKey.A:
				case ConsoleKey.LeftArrow:
					key = ActionType.Get("Left");
					break;

				case ConsoleKey.D:
				case ConsoleKey.RightArrow:
					key = ActionType.Get("Right");
					break;

				case ConsoleKey.Escape:
				case ConsoleKey.Q:
					key = ActionType.Get("Exit");
					break;

				case ConsoleKey.R:
					key = ActionType.Get("Reset");
					break;

				case ConsoleKey.T:
					key = ActionType.Get("Scores");
					break;

				default:
					key = ActionType.Get("Unmapped");
					break;
			}

			return key;
		}
	}
}