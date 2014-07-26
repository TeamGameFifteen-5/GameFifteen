namespace Game.UI.Windows.Forms.IOProviders
{
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	/// <summary>
	/// Interface for game form.
	/// </summary>
	public interface IGameForm
	{
		/// <summary>
		/// Gets or sets the last key.
		/// </summary>
		/// <value>
		/// The last key.
		/// </value>
		Keys? LastKey { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether is shift pressed.
		/// </summary>
		/// <value>
		/// true if shift is pressed, false if not.
		/// </value>
		bool IsShiftPressed { get; set; }

		/// <summary>
		/// Creates the graphics.
		/// </summary>
		/// <returns>
		/// The new graphics.
		/// </returns>
		Graphics CreateGraphics();

		/// <summary>
		/// Executes the given action.
		/// </summary>
		/// <param name="action">The action.</param>
		void Execute(Action action);
	}
}