namespace Game.UI.IOProviders.Settings
{
	/// <summary>
	/// Interface for Input/Output provider settings.
	/// </summary>
	public interface IIOProviderSettings
	{
		/// <summary>
		/// Applies the implemented settings to the given ioProvider.
		/// </summary>
		/// <param name="ioProvider">The i/o provider.</param>
		void Apply(IIOProvider ioProvider);
	}
}