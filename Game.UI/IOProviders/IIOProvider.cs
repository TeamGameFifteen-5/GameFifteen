using Game.Common;
using Game.UI.Renderers;
using System.Drawing;

namespace Game.UI.IOProviders
{
	/// <summary>
	/// Interface for Input/Output provider.
	/// </summary>
	public interface IIOProvider
	{
		/// <summary>
		/// Gets text input.
		/// </summary>
		/// <returns>
		/// The text input.
		/// </returns>
		string GetTextInput();

		/// <summary>
		/// Gets key input.
		/// </summary>
		/// <param name="displayKey">(optional) the display key.</param>
		/// <returns>
		/// The key input.
		/// </returns>
		ActionType GetKeyInput(bool displayKey = false);

		/// <summary>
		/// Displays the given output.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		void Display(string output = null);

		/// <summary>
		/// Displays the given output.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		void Display(string format, params string[] args);

		/// <summary>
		/// Displays a line described by output.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		void DisplayLine(string output = null);

		/// <summary>
		/// Displays a line described by output.
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

		/// <summary>
		/// Formats the given renderer.
		/// </summary>
		/// <param name="renderer">(optional) the renderer.</param>
		void Format(IRenderer renderer = null);
	}
}