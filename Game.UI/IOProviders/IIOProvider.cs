namespace Game.UI.IOProviders
{
	using Game.UI.IOProviders.Settings;

	/// <summary>
	/// Interface for Input/Output provider.
	/// </summary>
	/// <seealso cref="IInputProvider"/>
	public interface IIOProvider : IInputProvider, IOutputProvider
	{
		/// <summary>
		/// Applies the settings described by settings.
		/// </summary>
		/// <param name="settings">options for controlling the operation.</param>
		void ApplySettings(IIOProviderSettings settings);
	}
}