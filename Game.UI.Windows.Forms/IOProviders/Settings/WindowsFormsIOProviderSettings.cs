namespace Game.UI.Windows.Forms.IOProviders.Settings
{
    using System.Drawing;
    using Game.UI.IOProviders.Settings;

	public class WindowsFormsIOProviderSettings : IIOProviderSettings
	{
		public void Apply(UI.IOProviders.IIOProvider ioProvider)
		{
			ioProvider.ChangeColor(Color.Black);
		}
	}
}