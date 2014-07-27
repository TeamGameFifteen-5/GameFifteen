using Game.UI.IOProviders;
using Game.UI.IOProviders.Settings;
using Game.UI.Windows.Console.IOProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Game.UnitTests.GameUIWindowsConsole.IOProviders
{
	[TestClass]
	public class ConsoleIOProviderTest
	{
		[TestMethod]
		public void ConsoleIOProviderTesting()
		{
			var ioProvider = new ConsoleIOProvider();
			var color = Color.White;
			var defaultIOProviderSettings = new DefaultIOProviderSettings(color);
			ioProvider.ApplySettings(defaultIOProviderSettings);
			ioProvider.ChangeColor(color);
			ioProvider.ChangeStyle(IOStyleType.Normal);
			ioProvider.Display();
			ioProvider.DisplayLine();
			ioProvider.Invalidate();
			ioProvider.Map(new ConsoleKeyInfo('C', ConsoleKey.C, false, false, false));
		}
	}
}