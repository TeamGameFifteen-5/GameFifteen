namespace Game.UI.IOProviders
{
    using System.Drawing;
    using Game.UI.IOProviders.Settings;
    
	/// <summary>
	/// Interface for Input/Output provider.
	/// </summary>
	/// <seealso cref="IInputProvider"/>
	public interface IIOProvider : IInputProvider
	{
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
		/// Applies the settings described by settings.
		/// </summary>
		/// <param name="settings">(optional) options for controlling the operation.</param>
		void ApplySettings(IIOProviderSettings settings = null);
	}
}