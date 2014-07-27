namespace Game.UnitTests.GameUIWindowsConsole.IOProviders
{
	using Game.UI.IOProviders;
	using Game.UI.IOProviders.Settings;
	using Game.UI.Windows.Console.IOProviders;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;
	using System.IO;

	[TestClass]
	[ExcludeFromCodeCoverage]
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
			ioProvider.Map(new ConsoleKeyInfo('W', ConsoleKey.W, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('S', ConsoleKey.S, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('D', ConsoleKey.D, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('R', ConsoleKey.R, false, false, false));
			ioProvider.Map(new ConsoleKeyInfo('T', ConsoleKey.T, false, false, false));

			using (var memoryStream = new MemoryStream())
			using (var streamWriter = new StreamWriter(memoryStream))
			using (var streamReader = new StreamReader(memoryStream))
			{
				Console.SetIn(streamReader);

				streamWriter.WriteLine("A");
				streamWriter.WriteLine("Alive");
				streamWriter.Flush();
				memoryStream.Position = 0;
				ioProvider.GetTextInput();
			}
		}
	}
}