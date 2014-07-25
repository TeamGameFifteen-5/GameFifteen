namespace Game.UI.IOProviders
{
    using Game.Common;

	/// <summary>
	/// Interface for input provider.
	/// </summary>
	public interface IInputProvider
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
	}
}