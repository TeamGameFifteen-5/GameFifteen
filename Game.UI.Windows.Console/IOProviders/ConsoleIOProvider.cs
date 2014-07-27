namespace Game.UI.Windows.Console.IOProviders
{
	using Game.Common;
	using Game.UI.IOProviders;
	using Game.UI.KeyMappings;
	using Game.UI.Windows.Console.KeyMappings;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Console = System.Console;

	/// <summary>
	/// Represents Console Input/Output provider.
	/// </summary>
	/// <seealso cref="Game.UI.IOProviders.IOProvider"/>
	[ExcludeFromCodeCoverage]
	public class ConsoleIOProvider : IOProvider<ConsoleKeyInfo>
	{
		/// <summary>
		/// The key mapping.
		/// </summary>
		private IKeyMapping<ConsoleKeyInfo> _keyMapping;

		/// <summary>
		/// Gets the key mapping.
		/// </summary>
		/// <value>
		/// The key mapping.
		/// </value>
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

		/// <summary>
		/// Gets text input.
		/// </summary>
		/// <returns>
		/// The text input.
		/// </returns>
		public override string GetTextInput()
		{
			return Console.ReadLine();
		}

		/// <summary>
		/// Gets key input.
		/// </summary>
		/// <param name="displayKey">(optional) the display key.</param>
		/// <returns>
		/// The key input.
		/// </returns>
		public override ActionType GetKeyInput(bool displayKey = false)
		{
			var consoleKeyInfo = Console.ReadKey(!displayKey);
			return this.Map(consoleKeyInfo);
		}

		/// <summary>
		/// Displays the given output.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		public override void Display(string output = null)
		{
			Console.Write(output);
		}

		/// <summary>
		/// Displays the given arguments formated.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		public override void Display(string format, params string[] args)
		{
			this.ValidateFormatAndArgs(format, args);
			Console.Write(format, args);
		}

		/// <summary>
		/// Displays the given output and puts a new line at the end.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		public override void DisplayLine(string output = null)
		{
			Console.WriteLine(output);
		}

		/// <summary>
		/// Displays the given arguments formated and puts a new line at the end.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		public override void DisplayLine(string format, params string[] args)
		{
			this.ValidateFormatAndArgs(format, args);
			Console.WriteLine(format, args);
		}

		/// <summary>
		/// Change color.
		/// </summary>
		/// <param name="color">The color.</param>
		public override void ChangeColor(System.Drawing.Color color)
		{
			Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Name);
		}

		/// <summary>
		/// Change style.
		/// </summary>
		/// <param name="style">The style.</param>
		public override void ChangeStyle(IOStyleType style)
		{
		}

		/// <summary>
		/// Invalidates the output.
		/// </summary>
		public override void Invalidate()
		{
			Console.Clear();
		}
	}
}