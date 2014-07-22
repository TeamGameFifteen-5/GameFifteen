using Game.Core.Input;
using System;

namespace Game.UI.IOProviders
{
	public class ConsoleIOProvider : IOProvider
	{
		public override string GetTextInput()
		{
			return Console.ReadLine();
		}

		/// <summary>
		/// Gets key input.
		/// TODO: Pattern Implementation
		/// </summary>
		/// <param name="displayKey">(optional) the display key.</param>
		/// <returns>
		/// The key input.
		/// </returns>
		public override KeyType GetKeyInput(bool displayKey = false)
		{
			var consoleKeyInfo = Console.ReadKey(!displayKey);
			KeyType key;

			switch (consoleKeyInfo.Key)
			{
				case ConsoleKey.W:
				case ConsoleKey.UpArrow:
					key = KeyType.Up;
					break;

				case ConsoleKey.S:
				case ConsoleKey.DownArrow:
					key = KeyType.Down;
					break;

				case ConsoleKey.A:
				case ConsoleKey.LeftArrow:
					key = KeyType.Left;
					break;

				case ConsoleKey.D:
				case ConsoleKey.RightArrow:
					key = KeyType.Right;
					break;

				case ConsoleKey.Escape:
				case ConsoleKey.Q:
					key = KeyType.Exit;
					break;

				case ConsoleKey.R:
					key = KeyType.Reset;
					break;

				case ConsoleKey.T:
					key = KeyType.Scores;
					break;

				default:
					key = KeyType.Unmapped;
					break;
			}

			return key;
		}

		public override void Display(string output = null)
		{
			Console.Write(output);
		}

		public override void Display(string format, params string[] args)
		{
			Console.Write(format, args);
		}

		public override void DisplayLine(string output = null)
		{
			Console.WriteLine(output);
		}

		public override void DisplayLine(string format, params string[] args)
		{
			Console.WriteLine(format, args);
		}

		public override void ChangeColor(System.Drawing.Color color)
		{
			Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Name);
		}

		public override void ChangeStyle(IOStyleType style)
		{
		}

		public override void Invalidate()
		{
			Console.Clear();
		}
	}
}