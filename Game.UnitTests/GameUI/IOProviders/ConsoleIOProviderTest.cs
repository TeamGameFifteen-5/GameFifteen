namespace Game.UnitTests.GameUI.IOProviders
{
	using Game.Common;
	using Game.UI.Windows.Console.IOProviders;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class ConsoleIOProviderTest
	{
		[TestMethod]
		public void Map()
		{
			var ioProvider = new ConsoleIOProvider();
			var consoleKey = new System.ConsoleKeyInfo('W', System.ConsoleKey.W, false, false, false);
			var actionType = ioProvider.Map(consoleKey);

			Assert.AreEqual(actionType, ActionType.Get(DefaultActionTypes.Up));
		}
	}
}