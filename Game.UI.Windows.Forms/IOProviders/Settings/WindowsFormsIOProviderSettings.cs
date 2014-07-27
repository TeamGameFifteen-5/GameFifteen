namespace Game.UI.Windows.Forms.IOProviders.Settings
{
	using Game.Common.Utils;
	using Game.UI.IOProviders.Settings;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;

	/// <summary>
	/// Windows forms i/o provider settings.
	/// </summary>
	/// <seealso cref="Game.UI.IOProviders.Settings.IIOProviderSettings"/>
	[ExcludeFromCodeCoverage]
	public class WindowsFormsIOProviderSettings : IIOProviderSettings
	{
		/// <summary>
		/// Applies the implemented settings to the given ioProvider.
		/// </summary>
		/// <param name="ioProvider">The i/o provider.</param>
		public void Apply(UI.IOProviders.IIOProvider ioProvider)
		{
			Validation.ThrowIfNull(ioProvider);

			ioProvider.ChangeColor(Color.Black);
		}
	}
}