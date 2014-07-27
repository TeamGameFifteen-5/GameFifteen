namespace Game.UnitTests.GameUI.IOProviders
{
	using Game.Common;
	using Game.UI.IOProviders.Settings;
	using Game.UI.Windows.Console.IOProviders;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ConsoleIOProviderTest
	{
		[TestMethod]
		public void Map()
		{
			var ioProvider = new ConsoleIOProvider();
			var ioProviderSettings = new DefaultIOProviderSettings(Color.White);
			ioProvider.ApplySettings(ioProviderSettings);

			var consoleKey = new System.ConsoleKeyInfo('W', System.ConsoleKey.W, false, false, false);
			var actionType = ioProvider.Map(consoleKey);

			Assert.AreEqual(actionType, ActionType.Get(DefaultActionTypes.Up));
		}
	}
}