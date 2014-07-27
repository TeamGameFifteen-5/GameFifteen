namespace Game.UI.Windows.Console.KeyMappings
{
	using Game.Common;
	using Game.UI.KeyMappings;
	using System;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Represents Console key mapping.
	/// </summary>
	/// <seealso cref="Game.UI.KeyMappings.IKeyMapping"/>
	[ExcludeFromCodeCoverage]
	public class ConsoleKeyMapping : IKeyMapping<ConsoleKeyInfo>
	{
		public ActionType Map(ConsoleKeyInfo consoleKeyInfo)
		{
			ActionType key;

			switch (consoleKeyInfo.Key)
			{
				case ConsoleKey.W:
				case ConsoleKey.UpArrow:
					key = ActionType.Get(DefaultActionTypes.Up);
					break;

				case ConsoleKey.S:
				case ConsoleKey.DownArrow:
					key = ActionType.Get(DefaultActionTypes.Down);
					break;

				case ConsoleKey.A:
				case ConsoleKey.LeftArrow:
					key = ActionType.Get(DefaultActionTypes.Left);
					break;

				case ConsoleKey.D:
				case ConsoleKey.RightArrow:
					key = ActionType.Get(DefaultActionTypes.Right);
					break;

				case ConsoleKey.Escape:
				case ConsoleKey.Q:
					key = ActionType.Get(DefaultActionTypes.Exit);
					break;

				case ConsoleKey.R:
					key = ActionType.Get(DefaultActionTypes.Reset);
					break;

				case ConsoleKey.T:
					key = ActionType.Get(DefaultActionTypes.Scores);
					break;

				default:
					key = ActionType.Get(DefaultActionTypes.Unmapped);
					break;
			}

			return key;
		}
	}
}