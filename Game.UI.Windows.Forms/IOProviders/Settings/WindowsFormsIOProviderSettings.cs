using Game.UI.IOProviders.Settings;
using System.Drawing;

namespace Game.UI.Windows.Forms.IOProviders.Settings
{
	public class WindowsFormsIOProviderSettings : IIOProviderSettings
	{
		public void Apply(UI.IOProviders.IIOProvider ioProvider)
		{
			ioProvider.ChangeColor(Color.White);
		}
	}
}