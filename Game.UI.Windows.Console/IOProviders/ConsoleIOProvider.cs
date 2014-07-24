namespace Game.UI.Windows.Console.IOProviders
{
	using Game.Common;
	using Game.UI.IOProviders;
	using Game.UI.KeyMappings;
	using Game.UI.Windows.Console.KeyMappings;
	using System;
	using Console = System.Console;

	/// <summary>
	/// Represents Console Input/Output provider.
	/// </summary>
	/// <seealso cref="Game.UI.IOProviders.IOProvider"/>
	public class ConsoleIOProvider : IOProvider<ConsoleKeyInfo>
	{
		private IKeyMapping<ConsoleKeyInfo> _keyMapping;

		public ConsoleIOProvider()
		{
		}

		protected override IKeyMapping<ConsoleKeyInfo> KeyMapping
		{
			get
			{
				if (this._keyMapping == null)
				{
					this._keyMapping = new ConsoleKeyMapping();
				}
				return this._keyMapping;
			}
		}

		public override string GetTextInput()
		{
			return Console.ReadLine();
		}

		public override ActionType GetKeyInput(bool displayKey = false)
		{
			var consoleKeyInfo = Console.ReadKey(!displayKey);
			return this.Map(consoleKeyInfo);
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