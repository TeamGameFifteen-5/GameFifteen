namespace Game.UI.IOProviders
{
	using System.Drawing;

	/// <summary>
	/// Interface for output provider.
	/// </summary>
	public interface IOutputProvider
	{
		/// <summary>
		/// Displays the given output.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		void Display(string output = null);

		/// <summary>
		/// Displays the given arguments formated.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		void Display(string format, params string[] args);

		/// <summary>
		/// Displays the given output and puts a new line at the end.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		void DisplayLine(string output = null);

		/// <summary>
		/// Displays the given arguments formated and puts a new line at the end.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		void DisplayLine(string format, params string[] args);

		/// <summary>
		/// Change color.
		/// </summary>
		/// <param name="color">The color.</param>
		void ChangeColor(Color color);

		/// <summary>
		/// Change style.
		/// </summary>
		/// <param name="style">The style.</param>
		void ChangeStyle(IOStyleType style);

		/// <summary>
		/// Invalidates the output.
		/// </summary>
		void Invalidate();
	}
}